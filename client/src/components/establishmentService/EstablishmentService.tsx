import { useEffect, useState } from "react";
import {
  CreateEstablishmentServiceRequest,
  EstablishmentObject,
  EstablishmentServiceObject,
  UpdateEstablishmentServiceRequest,
} from "../../scripts/interfaces";
import {
  AddEstablishmentService,
  DeleteEstablishmentService,
  fetchAllEstablishmentServices,
  fetchEstablishmentService,
  UpdateEstablishmentService,
} from "../../scripts/establishmentServiceFunctions";
import { v4 as uuidv4 } from "uuid";
import { fetchAllEstablishments } from "../../scripts/establishmentFunctions";
import EstablishmentServiceTable from "./EstablishmentServiceTable";
import Pagination from "../Pagination";
import EditEstablishmentServiceModal from "./EditEstablishmentServiceModal";
import AddEstablishmentServiceModal from "./AddEstablishmentServiceModal";
import Navbar from "../Navbar";

function EstablishmentService() {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [establishmentServices, setEstablishmentServices] = useState<
    EstablishmentServiceObject[]
  >([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedEstablishmentService, setSelectedEstablishmentService] =
    useState<EstablishmentServiceObject | null>(null);
  const [establishments, setEstablishments] = useState<EstablishmentObject[]>(
    []
  );

  const paginatedEstablishmentServices = establishmentServices.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing EstablishmentService
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditEstablishmentServiceName, setNewEditEstablishmentServiceName] =
    useState("");
  const [
    newEditEstablishmentServicePrice,
    setNewEditEstablishmentServicePrice,
  ] = useState(0);
  const [
    newEditEstablishmentServiceCurrency,
    setNewEditEstablishmentServiceCurrency,
  ] = useState(0);

  // Used for Adding EstablishmentService
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddEstablishmentServiceName, setNewAddEstablishmentServiceName] =
    useState("");
  const [newAddEstablishmentServicePrice, setNewAddEstablishmentServicePrice] =
    useState(0);
  const [
    newAddEstablishmentServiceCurrency,
    setNewAddEstablishmentServiceCurrency,
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
        const selectedEstablishmentService = await fetchEstablishmentService(
          establishmentProductId
        );

        console.log(
          "Fetched selected establishment service details: ",
          selectedEstablishmentService
        );
        setSelectedEstablishmentService(selectedEstablishmentService);
        setExpandedRow(index);
      } catch (error) {
        console.error("Error fetching establishment service details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedEstablishmentService) {
      setShowEditModal(true);
      setNewEditEstablishmentServiceName(selectedEstablishmentService.name);
      setNewEditEstablishmentServicePrice(selectedEstablishmentService.price);
      setNewEditEstablishmentServiceCurrency(
        selectedEstablishmentService.currency
      );
    }
  };

  const toggleEditEstablishmentServiceModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddEstablishmentServiceModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (type === "select-one") {
      if (name === "currency") {
        setNewEditEstablishmentServiceCurrency(Number(value));
      }
    } else if (type === "text" || type === "number") {
      if (name === "price")
        setNewEditEstablishmentServicePrice(parseFloat(value));
      if (name === "name") setNewEditEstablishmentServiceName(value);
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
        setNewAddEstablishmentServiceCurrency(Number(value));
      }
    } else if (type === "text" || type === "number") {
      if (name === "price")
        setNewAddEstablishmentServicePrice(parseFloat(value));
      if (name === "name") setNewAddEstablishmentServiceName(value);
    }
  };

  const handleEditSaveEstablishmentService = async () => {
    console.log("Pressed Edit Save");
    if (selectedEstablishmentService) {
      const updatedEstablishmentService: UpdateEstablishmentServiceRequest = {
        id: selectedEstablishmentService.id,
        name: newEditEstablishmentServiceName,
        price: newEditEstablishmentServicePrice,
        currency: newEditEstablishmentServiceCurrency,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateEstablishmentService(
        updatedEstablishmentService
      );

      if (!success) {
        alert("Failed to update establishment service");
        return;
      }

      alert("Establishment service updated successfully");

      toggleEditEstablishmentServiceModal();
      setExpandedRow(null);
      loadEstablishmentServices();
    }
  };

  const handleAddSaveEstablishmentServices = async () => {
    console.log("Pressed Edit Save");
    const newEstablishmentService: CreateEstablishmentServiceRequest = {
      id: uuidv4(),
      name: newAddEstablishmentServiceName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      price: newAddEstablishmentServicePrice,
      currency: newAddEstablishmentServiceCurrency,
      orders: [],
      fkEstablishmentId: newEstablishmentId,
    };

    console.log(
      "Add establishment service request body: ",
      newEstablishmentService
    );

    const success = await AddEstablishmentService(newEstablishmentService);

    if (!success) {
      alert("Failed to add establishment service");
      return;
    }

    alert("Establishment service added successfully");

    toggleAddEstablishmentServiceModal();
    loadEstablishmentServices();
    setNewAddEstablishmentServiceName("");
    setNewAddEstablishmentServicePrice(0);
    setNewAddEstablishmentServiceCurrency(0);
    setNewEstablishmentId("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedEstablishmentService) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedEstablishmentService.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteEstablishmentService(
          selectedEstablishmentService.id
        );

        if (!success) {
          alert("Failed to delete establishment service");
          return;
        }

        alert("Establishment service deleted successfully");

        setExpandedRow(null);
        loadEstablishmentServices();
      }
    }
  };

  const loadEstablishmentServices = async () => {
    try {
      setLoading(true);
      const data = await fetchAllEstablishmentServices();
      console.log("Retrieved from function loadEstablishmentServices: ", data);
      setEstablishmentServices(data);
      const establishments = await fetchAllEstablishments();
      setEstablishments(establishments);
    } catch (error) {
      console.error("Error loading establishment services: ", error);
    } finally {
      setLoading(false);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadEstablishmentServices();
  }, []);

  return (
    <>
      <Navbar />
      <h1 className="text-center mb-4">Establishment Products</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <EstablishmentServiceTable
            establishmentServices={establishmentServices}
            paginatedEstablishmentServices={paginatedEstablishmentServices}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedEstablishmentService={selectedEstablishmentService}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(establishmentServices.length / pageSize)}
          totalItems={establishmentServices.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddEstablishmentServiceModal}
          >
            Add Establishment Service
          </button>
        </div>
      </div>
      <EditEstablishmentServiceModal
        showModal={showEditModal}
        toggleModal={toggleEditEstablishmentServiceModal}
        newEstablishmentServiceName={newEditEstablishmentServiceName}
        newEstablishmentServicePrice={newEditEstablishmentServicePrice}
        newEstablishmentServiceCurrency={newEditEstablishmentServiceCurrency}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveEstablishmentService}
      />
      <AddEstablishmentServiceModal
        showModal={showAddModal}
        toggleModal={toggleAddEstablishmentServiceModal}
        newEstablishmentServiceName={newAddEstablishmentServiceName}
        newEstablishmentServicePrice={newAddEstablishmentServicePrice}
        newEstablishmentServiceCurrency={newAddEstablishmentServiceCurrency}
        establishments={establishments}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveEstablishmentServices}
      />
    </>
  );
}

export default EstablishmentService;
