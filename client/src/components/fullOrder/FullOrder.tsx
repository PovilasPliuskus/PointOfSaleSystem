import { useEffect, useState } from "react";
import {
  CreateFullOrderRequest,
  EstablishmentObject,
  FullOrderObject,
  UpdateFullOrderRequest,
} from "../../scripts/interfaces";
import FullOrderTable from "./FullOrderTable";
import {
  AddFullOrder,
  DeleteFullOrder,
  fetchAllFullOrders,
  fetchFullOrder,
  UpdateFullOrder,
  createCheckoutSession
} from "../../scripts/fullOrderFunctions";
import { v4 as uuidv4 } from "uuid";
import Pagination from "../Pagination";
import EditFullOrderModal from "./EditFullOrderModal";
import AddFullOrderModal from "./AddFullOrderModal";
import Navbar from "../Navbar";
import { fetchAllEstablishments } from "../../scripts/establishmentFunctions";
import { loadStripe } from '@stripe/stripe-js';

function FullOrder() {
  // Variables
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [fullOrders, setFullOrders] = useState<FullOrderObject[]>([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedFullOrder, setSelectedFullOrder] =
    useState<FullOrderObject | null>(null);
  const [establishments, setEstablishments] = useState<EstablishmentObject[]>(
    []
  );

  const paginatedFullOrders = fullOrders.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing Full Order
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditFullOrderTip, setNewEditFullOrderTip] = useState(0.0);
  const [newEditFullOrderStatus, setNewEditFullOrderStatus] = useState(1);
  const [newEditFullOrderName, setNewEditFullOrderName] = useState("");

  // Used for Adding Full Order
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddFullOrderTip, setNewAddFullOrderTip] = useState(0.0);
  const [newAddFullOrderStatus, setNewAddFullOrderStatus] = useState(1);
  const [newAddFullOrderName, setNewAddFullOrderName] = useState("");
  const [newEstablishmentsId, setNewEstablishmentsId] = useState("");

  // Functions
  const handleRowClick = async (index: number, fullOrderId: string) => {
    console.log("Pressed handleRowClick");

    setExpandedRow(expandedRow === index ? null : index);

    if (expandedRow !== index) {
      try {
        const selectedFullOrder = await fetchFullOrder(fullOrderId);

        console.log("Fetched selected full order details: ", selectedFullOrder);
        setSelectedFullOrder(selectedFullOrder);
      } catch (error) {
        console.error("Error fetching full order details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedFullOrder) {
      setShowEditModal(true);
      setNewEditFullOrderName(selectedFullOrder.name);
      setNewEditFullOrderTip(selectedFullOrder.tip);
      setNewEditFullOrderStatus(selectedFullOrder.status);
    }
  };

  const stripePromise = loadStripe('pk_test_51QXkdiLNotqjmzonh6Eq93L5S2bUfSPq65hRjvgl8jk8Apna9rzX97Pu2UlzcTrnUt352FNzRs12lZt3e5pZAg3d000iElLPhP');

  const handleCheckoutClick = async () => {
    console.log("Pressed handleCheckoutClick");
    var session = await createCheckoutSession(selectedFullOrder!.id);
    console.log(session);
    // redirect to session.sessionId

      const stripe = await stripePromise;
      stripe!.redirectToCheckout({ sessionId: session.sessionId });
    
  };

  const toggleEditFullOrderModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddFullOrderModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (type === "select-one") {
      if (name === "status") {
        setNewEditFullOrderStatus(Number(value));
      }
    } else if (type === "text" || type === "number") {
      if (name === "name") {
        setNewEditFullOrderName(value);
      } else if (name === "tip") {
        setNewEditFullOrderTip(parseFloat(value));
      }
    }
  };

  const handleAddInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (type === "select-one") {
      if (name === "status") {
        setNewAddFullOrderStatus(Number(value));
      }
      if (name === "establishmentId") {
        setNewEstablishmentsId(value);
      }
    } else if (type === "text" || type === "number") {
      if (name === "name") {
        setNewAddFullOrderName(value);
      } else if (name === "tip") {
        setNewAddFullOrderTip(parseFloat(value));
      }
    }
  };

  const handleEditSaveFullOrder = async () => {
    console.log("Pressed Edit Save");
    if (selectedFullOrder) {
      const updatedFullOrder: UpdateFullOrderRequest = {
        id: selectedFullOrder.id,
        tip: newEditFullOrderTip,
        status: newEditFullOrderStatus,
        name: newEditFullOrderName,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateFullOrder(updatedFullOrder);

      if (!success) {
        alert("Failed to update full order");
        return;
      }

      alert("Full order updated successfully");

      toggleEditFullOrderModal();
      setExpandedRow(null);
      loadFullOrders();
    }
  };

  const handleAddSaveFullOrder = async () => {
    console.log("Pressed Edit Save");
    const newFullOrder: CreateFullOrderRequest = {
      id: uuidv4(),
      name: newAddFullOrderName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      establishmentId: newEstablishmentsId,
      orders: [],
      tip: newAddFullOrderTip,
      status: newAddFullOrderStatus,
    };

    console.log("Add Full order request body: ", newFullOrder);

    const success = await AddFullOrder(newFullOrder);

    if (!success) {
      alert("Failed to add full order");
      return;
    }

    alert("Full order added successfully");

    toggleAddFullOrderModal();
    loadFullOrders();
    setNewAddFullOrderName("");
    setNewAddFullOrderTip(0.0);
    setNewAddFullOrderStatus(1);
    setNewEstablishmentsId("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedFullOrder) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedFullOrder.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteFullOrder(selectedFullOrder.id);

        if (!success) {
          alert("Failed to delete full order");
          return;
        }

        alert("Full order deleted successfully");

        setExpandedRow(null);
        loadFullOrders();
      }
    }
  };

  const loadFullOrders = async () => {
    try {
      setLoading(true);
      const data = await fetchAllFullOrders();
      console.log("Retrieved from function loadFullOrders: ", data);
      setFullOrders(data);
      const establishments = await fetchAllEstablishments();
      setEstablishments(establishments);
    } catch (error) {
      console.error("Error loading full olders: ", error);
    } finally {
      setLoading(false);
    }
  };

  const refundOrder = async (orderId: string) => {
    try {
      // Update the order status in the database
      const response = await fetch(`/api/orders/${orderId}/refund`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
      });
  
      if (!response.ok) {
        throw new Error('Failed to refund order');
      }
  
      const result = await response.json();
      console.log(`Order with ID: ${orderId} refunded successfully`, result);
      alert(`Order with ID: ${orderId} refunded successfully`);
  
      // const paymentResponse = await processPaymentRefund(orderId);
      // if (!paymentResponse.success) {
      //   throw new Error('Failed to process payment refund');
      // }
  
      loadFullOrders();
    } catch (error) {
      console.error(`Error refunding order with ID: ${orderId}`, error);
      alert(`Failed to refund order with ID: ${orderId}`);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadFullOrders();
  }, []);

  return (
    <>
      <Navbar />
      <h1 className="text-center mb-4">Full Orders</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <FullOrderTable
            fullOrders={fullOrders}
            paginatedFullOrders={paginatedFullOrders}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedFullOrder={selectedFullOrder}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
            handleCheckoutClick={handleCheckoutClick}
            handleRefundClick={refundOrder}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(fullOrders.length / pageSize)}
          totalItems={fullOrders.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddFullOrderModal}
          >
            Add Full Order
          </button>
        </div>
      </div>
      <EditFullOrderModal
        showModal={showEditModal}
        toggleModal={toggleEditFullOrderModal}
        newFullOrderName={newEditFullOrderName}
        newFullOrderStatus={newEditFullOrderStatus}
        newFullOrderTip={newEditFullOrderTip}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveFullOrder}
      />
      <AddFullOrderModal
        showModal={showAddModal}
        toggleModal={toggleAddFullOrderModal}
        newFullOrderName={newAddFullOrderName}
        newFullOrderStatus={newAddFullOrderStatus}
        newFullOrderTip={newAddFullOrderTip}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveFullOrder}
        establishments={establishments}
      />
    </>
  );
}

export default FullOrder;
