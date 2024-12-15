import { useEffect, useState } from "react";
import {
  CreateEstablishmentProductRequest,
  EstablishmentObject,
  EstablishmentProductObject,
  UpdateEstablishmentProductRequest,
} from "../../scripts/interfaces";
import { fetchAllEstablishments } from "../../scripts/establishmentFunctions";
import {
  AddEstablishmentProduct,
  DeleteEstablishmentProduct,
  fetchAllEstablishmentProducts,
  fetchEstablishmentProduct,
  UpdateEstablishmentProduct,
} from "../../scripts/establishmentProductFunctions";
import { v4 as uuidv4 } from "uuid";
import EstablishmentProductTable from "./EstablishmentProductTable";
import Pagination from "../Pagination";
import EditEstablishmentProductModal from "./EditEstablishmentProductModal";
import AddEstablishmentProductModal from "./AddEstablishmentProductModal";

function EstablishmentProduct() {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [establishmentProducts, setEstablishmentProducts] = useState<
    EstablishmentProductObject[]
  >([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedEstablishmentProduct, setSelectedEstablishmentProduct] =
    useState<EstablishmentProductObject | null>(null);
  const [establishments, setEstablishments] = useState<EstablishmentObject[]>(
    []
  );

  const paginatedEstablishmentProducts = establishmentProducts.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing EstablishmentProduct
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditEstablishmentProductName, setNewEditEstablishmentProductName] =
    useState("");
  const [
    newEditEstablishmentProductPrice,
    setNewEditEstablishmentProductPrice,
  ] = useState(0);
  const [
    newEditEstablishmentProductAmountInStock,
    setNewEditEstablishmentProductAmountInStock,
  ] = useState(0);
  const [
    newEditEstablishmentProductCurrency,
    setNewEditEstablishmentProductCurrency,
  ] = useState(0);

  // Used for Adding EstablishmentProduct
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddEstablishmentProductName, setNewAddEstablishmentProductName] =
    useState("");
  const [newAddEstablishmentProductPrice, setNewAddEstablishmentProductPrice] =
    useState(0);
  const [
    newAddEstablishmentProductAmountInStock,
    setNewAddEstablishmentProductAmountInStock,
  ] = useState(0);
  const [
    newAddEstablishmentProducCurrency,
    setNewAddEstablishmentProductCurrency,
  ] = useState(0);
  const [newEstablishmentId, setNewEstablishmentId] = useState("");

  // Functions
  const handleRowClick = async (
    index: number,
    establishmentProductId: string
  ) => {
    console.log("Pressed handleRowClick");

    if (expandedRow === index) {
      setExpandedRow(null);
      return;
    }

    if (expandedRow !== index) {
      try {
        const selectedEstablishmentProduct = await fetchEstablishmentProduct(
          establishmentProductId
        );

        console.log(
          "Fetched selected establishment product details: ",
          selectedEstablishmentProduct
        );
        setSelectedEstablishmentProduct(selectedEstablishmentProduct);
        setExpandedRow(index);
      } catch (error) {
        console.error("Error fetching establishment product details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedEstablishmentProduct) {
      setShowEditModal(true);
      setNewEditEstablishmentProductName(selectedEstablishmentProduct.name);
      setNewEditEstablishmentProductPrice(selectedEstablishmentProduct.price);
      setNewEditEstablishmentProductAmountInStock(
        selectedEstablishmentProduct.amountInStock
      );
      setNewEditEstablishmentProductCurrency(
        selectedEstablishmentProduct.currency
      );
    }
  };

  const toggleEditEstablishmentProductModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddEstablishmentProductModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (type === "select-one") {
      if (name === "currency") {
        setNewEditEstablishmentProductCurrency(Number(value));
      }
    } else if (type === "text" || type === "number") {
      if (name === "price")
        setNewEditEstablishmentProductPrice(parseFloat(value));
      if (name === "name") setNewEditEstablishmentProductName(value);
      if (name === "amountInStock")
        setNewEditEstablishmentProductAmountInStock(Number(value));
    }
  };

  const handleAddInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (name === "establishmentId") {
      setNewEstablishmentId(value);
      console.log(`VALUE = ${newEstablishmentId}`);
    }

    if (type === "select-one") {
      if (name === "currency") {
        setNewAddEstablishmentProductCurrency(Number(value));
      }
    } else if (type === "text" || type === "number") {
      if (name === "price")
        setNewAddEstablishmentProductPrice(parseFloat(value));
      if (name === "name") setNewAddEstablishmentProductName(value);
      if (name === "amountInStock")
        setNewAddEstablishmentProductAmountInStock(Number(value));
    }
  };

  const handleEditSaveEstablishmentProduct = async () => {
    console.log("Pressed Edit Save");
    if (selectedEstablishmentProduct) {
      const updatedEstablishmentProduct: UpdateEstablishmentProductRequest = {
        id: selectedEstablishmentProduct.id,
        name: newEditEstablishmentProductName,
        price: newEditEstablishmentProductPrice,
        amountInStock: newEditEstablishmentProductAmountInStock,
        currency: newEditEstablishmentProductCurrency,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateEstablishmentProduct(
        updatedEstablishmentProduct
      );

      if (!success) {
        alert("Failed to update establishment product");
        return;
      }

      alert("Establishment product updated successfully");

      toggleEditEstablishmentProductModal();
      setExpandedRow(null);
      loadEstablishmentProducts();
    }
  };

  const handleAddSaveEstablishmentProducts = async () => {
    console.log("Pressed Edit Save");
    const newEstablishmentProduct: CreateEstablishmentProductRequest = {
      id: uuidv4(),
      name: newAddEstablishmentProductName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      price: newAddEstablishmentProductPrice,
      amountInStock: newAddEstablishmentProductAmountInStock,
      currency: newAddEstablishmentProducCurrency,
      orders: [],
      fkEstablishmentId: newEstablishmentId,
    };

    console.log(
      "Add establishment product request body: ",
      newEstablishmentProduct
    );

    const success = await AddEstablishmentProduct(newEstablishmentProduct);

    if (!success) {
      alert("Failed to add establishment product");
      return;
    }

    alert("Establishment product added successfully");

    toggleAddEstablishmentProductModal();
    loadEstablishmentProducts();
    setNewAddEstablishmentProductName("");
    setNewAddEstablishmentProductPrice(0);
    setNewAddEstablishmentProductAmountInStock(0);
    setNewAddEstablishmentProductCurrency(0);
    setNewEstablishmentId("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedEstablishmentProduct) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedEstablishmentProduct.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteEstablishmentProduct(
          selectedEstablishmentProduct.id
        );

        if (!success) {
          alert("Failed to delete establishment product");
          return;
        }

        alert("Establishment product deleted successfully");

        setExpandedRow(null);
        loadEstablishmentProducts();
      }
    }
  };

  const loadEstablishmentProducts = async () => {
    try {
      setLoading(true);
      const data = await fetchAllEstablishmentProducts();
      console.log("Retrieved from function loadEstablishmentProducts: ", data);
      setEstablishmentProducts(data);
      const establishments = await fetchAllEstablishments();
      setEstablishments(establishments);
    } catch (error) {
      console.error("Error loading establishment products: ", error);
    } finally {
      setLoading(false);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadEstablishmentProducts();
  }, []);

  return (
    <>
      <h1 className="text-center mb-4">Establishment Products</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <EstablishmentProductTable
            establishmentProducts={establishmentProducts}
            paginatedEstablishmentProducts={paginatedEstablishmentProducts}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedEstablishmentProduct={selectedEstablishmentProduct}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(establishmentProducts.length / pageSize)}
          totalItems={establishmentProducts.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddEstablishmentProductModal}
          >
            Add Establishment Product
          </button>
        </div>
      </div>
      <EditEstablishmentProductModal
        showModal={showEditModal}
        toggleModal={toggleEditEstablishmentProductModal}
        newEstablishmentProductName={newEditEstablishmentProductName}
        newEstablishmentProductPrice={newEditEstablishmentProductPrice}
        newEstablishmentProductAmountInStock={
          newEditEstablishmentProductAmountInStock
        }
        newEstablishmentProductCurrency={newEditEstablishmentProductCurrency}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveEstablishmentProduct}
      />
      <AddEstablishmentProductModal
        showModal={showAddModal}
        toggleModal={toggleAddEstablishmentProductModal}
        newEstablishmentProductName={newAddEstablishmentProductName}
        newEstablishmentProductPrice={newAddEstablishmentProductPrice}
        newEstablishmentProductAmountInStock={
          newAddEstablishmentProductAmountInStock
        }
        newEstablishmentProductCurrency={newAddEstablishmentProducCurrency}
        establishments={establishments}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveEstablishmentProducts}
      />
    </>
  );
}

export default EstablishmentProduct;
