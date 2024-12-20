import { useEffect, useState } from "react";
import {
  CreateOrderRequest,
  EstablishmentProductObject,
  EstablishmentServiceObject,
  FullOrderObject,
  OrderObject,
  UpdateOrderRequest,
} from "../../scripts/interfaces";
import {
  AddOrder,
  DeleteOrder,
  fetchAllOrders,
  fetchOrder,
  UpdateOrder,
} from "../../scripts/orderFunctions";
import { v4 as uuidv4 } from "uuid";
import Pagination from "../Pagination";
import OrderTable from "./OrderTable";
import EditOrderModal from "./EditOrderModal";
import AddOrderModal from "./AddOrderModal";
import { fetchAllFullOrders } from "../../scripts/fullOrderFunctions";
import Navbar from "../Navbar";
import { fetchAllEstablishmentProducts } from "../../scripts/establishmentProductFunctions";
import { fetchAllEstablishmentServices } from "../../scripts/establishmentServiceFunctions";

function Order() {
  // Variables
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [orders, setOrders] = useState<OrderObject[]>([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedOrder, setSelectedOrder] = useState<OrderObject | null>(null);
  const [fullOrders, setFullOrders] = useState<FullOrderObject[]>([]);
  const [establishmentProducts, setEstablishmentProducts] = useState<
    EstablishmentProductObject[]
  >([]);
  const [establishmentServices, setEstablishmentServices] = useState<
    EstablishmentServiceObject[]
  >([]);

  const paginatedOrders = orders.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing Order
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditOrderCount, setNewEditOrderCount] = useState(0);
  const [newEditOrderName, setNewEditOrderName] = useState("");

  // Used for Adding Order
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddOrderCount, setNewAddOrderCount] = useState(0);
  const [newAddOrderName, setNewAddOrderName] = useState("");
  const [newFullOrdersId, setNewFullOrdersId] = useState("");
  const [newEstablishmentProductsId, setNewEstablishmentProductsId] =
    useState("");
  const [newEstablishmentServiceId, setNewEstablishmentServiceId] =
    useState("");

  // Functions
  const handleRowClick = async (index: number, orderId: string) => {
    console.log("Pressed handleRowClick");

    if (expandedRow === index) {
      setExpandedRow(null);
      return;
    }

    if (expandedRow !== index) {
      try {
        const selectedOrder = await fetchOrder(orderId);

        console.log("Fetched selected order details: ", selectedOrder);
        setSelectedOrder(selectedOrder);
        setExpandedRow(index);
      } catch (error) {
        console.error("Error fetching order details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedOrder) {
      setShowEditModal(true);
      setNewEditOrderName(selectedOrder.name);
      setNewEditOrderCount(selectedOrder.count);
    }
  };

  const toggleEditOrderModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddOrderModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    if (name === "count") setNewEditOrderCount(parseFloat(value));
    if (name === "name") setNewEditOrderName(value);
  };

  const handleAddInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    if (name === "count") setNewAddOrderCount(parseFloat(value));
    if (name === "name") setNewAddOrderName(value);
    if (name === "fullOrderId") {
      setNewFullOrdersId(value);
      console.log(`VALUE = ${newFullOrdersId}`);
    }
    if (name === "establishmentProductId") {
      setNewEstablishmentProductsId(value);
    }
    if (name === "establishmentServiceId") {
      setNewEstablishmentServiceId(value);
    }
  };

  const handleEditSaveOrder = async () => {
    console.log("Pressed Edit Save");
    if (selectedOrder) {
      const updatedOrder: UpdateOrderRequest = {
        id: selectedOrder.id,
        name: newEditOrderName,
        count: newEditOrderCount,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateOrder(updatedOrder);

      if (!success) {
        alert("Failed to update order");
        return;
      }

      alert("Order updated successfully");

      toggleEditOrderModal();
      setExpandedRow(null);
      loadOrders();
    }
  };

  const handleAddSaveOrder = async () => {
    console.log("Pressed Edit Save");
    const newOrder: CreateOrderRequest = {
      id: uuidv4(),
      name: newAddOrderName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      establishmentProductId:
        newEstablishmentProductsId === "" ? null : newEstablishmentProductsId,
      establishmentServiceId:
        newEstablishmentServiceId === "" ? null : newEstablishmentServiceId,
      count: newAddOrderCount,
      fkFullOrderId: newFullOrdersId,
    };

    console.log("Add Order request body: ", newOrder);

    const success = await AddOrder(newOrder);

    if (!success) {
      alert("Failed to add order");
      return;
    }

    alert("Order added successfully");

    toggleAddOrderModal();
    loadOrders();
    setNewAddOrderCount(0);
    setNewAddOrderName("");
    setNewFullOrdersId("");
    setNewEstablishmentProductsId("");
    setNewEstablishmentServiceId("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedOrder) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedOrder.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteOrder(selectedOrder.id);

        if (!success) {
          alert("Failed to delete order");
          return;
        }

        alert("Order deleted successfully");

        setExpandedRow(null);
        loadOrders();
      }
    }
  };

  const loadOrders = async () => {
    try {
      setLoading(true);
      const data = await fetchAllOrders();
      console.log("Retrieved from function loadOrders: ", data);
      setOrders(data);
      const fullOrders = await fetchAllFullOrders();
      setFullOrders(fullOrders);
      const establishmentProducts = await fetchAllEstablishmentProducts();
      setEstablishmentProducts(establishmentProducts);
      const establishmentServices = await fetchAllEstablishmentServices();
      setEstablishmentServices(establishmentServices);
    } catch (error) {
      console.error("Error loading orders: ", error);
    } finally {
      setLoading(false);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadOrders();
  }, []);

  return (
    <>
      <Navbar />
      <h1 className="text-center mb-4">Orders</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <OrderTable
            orders={orders}
            paginatedOrders={paginatedOrders}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedOrder={selectedOrder}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(orders.length / pageSize)}
          totalItems={orders.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddOrderModal}
          >
            Add Order
          </button>
        </div>
      </div>
      <EditOrderModal
        showModal={showEditModal}
        toggleModal={toggleEditOrderModal}
        newOrderCount={newEditOrderCount}
        newOrderName={newEditOrderName}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveOrder}
      />
      <AddOrderModal
        showModal={showAddModal}
        toggleModal={toggleAddOrderModal}
        newOrderCount={newAddOrderCount}
        newOrderName={newAddOrderName}
        fullOrders={fullOrders}
        establishmentProducts={establishmentProducts}
        establishmentServices={establishmentServices}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveOrder}
      />
    </>
  );
}

export default Order;
