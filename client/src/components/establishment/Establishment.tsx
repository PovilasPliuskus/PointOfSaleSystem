import { useEffect, useState } from "react";
import {
  CreateEstablishmentRequest,
  EstablishmentObject,
  UpdateEstablishmentRequest,
} from "../../scripts/interfaces";
import {
  AddEstablishment,
  DeleteEstablishment,
  fetchAllEstablishments,
  fetchEstablishment,
  UpdateEstablishment,
} from "../../scripts/establishmentFunctions";
import { v4 as uuidv4 } from "uuid";
import EstablishmentTable from "./EstablishmentTable";
import Pagination from "../Pagination";
import EditEstablishmentModal from "./EditEstablishmentModal";
import AddEstablishmentModal from "./AddEstablishmentModal";

function Establishment() {
  // Variables
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [establishments, setEstablishments] = useState<EstablishmentObject[]>(
    []
  );
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedEstablishment, setSelectedEstablishment] =
    useState<EstablishmentObject | null>(null);

  const paginatedEstablishments = establishments.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing Company
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditEstablishmentCode, setNewEditEstablishmentCode] = useState("");
  const [newEditEstablishmentName, setNewEditEstablishmentName] = useState("");

  // Used for Adding Company
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddEstablishmentCode, setNewAddEstablishmentCode] = useState("");
  const [newAddEstablishmentName, setNewAddEstablishmentName] = useState("");

  // Functions
  const handleRowClick = async (index: number, establishmentId: string) => {
    console.log("Pressed handleRowClick");

    setExpandedRow(expandedRow === index ? null : index);

    if (expandedRow !== index) {
      try {
        const selectedEstablishment = await fetchEstablishment(establishmentId);

        console.log(
          "Fetched selected establishment details: ",
          selectedEstablishment
        );
        setSelectedEstablishment(selectedEstablishment);
      } catch (error) {
        console.error("Error fetching establishment details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedEstablishment) {
      setShowEditModal(true);
      setNewEditEstablishmentName(selectedEstablishment.name);
      setNewEditEstablishmentCode(selectedEstablishment.code);
    }
  };

  const toggleEditEstablishmentModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddEstablishmentModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    if (name === "code") setNewEditEstablishmentCode(value);
    if (name === "name") setNewEditEstablishmentName(value);
  };

  const handleAddInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    if (name === "code") setNewAddEstablishmentCode(value);
    if (name === "name") setNewAddEstablishmentName(value);
  };

  const handleEditSaveEstablishment = async () => {
    console.log("Pressed Edit Save");
    if (selectedEstablishment) {
      const updatedEstablishment: UpdateEstablishmentRequest = {
        id: selectedEstablishment.id,
        code: newEditEstablishmentCode,
        name: newEditEstablishmentName,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateEstablishment(updatedEstablishment);

      if (!success) {
        alert("Failed to update establishment");
        return;
      }

      alert("Establishment updated successfully");

      toggleEditEstablishmentModal();
      setExpandedRow(null);
      loadEstablishments();
    }
  };

  const handleAddSaveEstablishment = async () => {
    console.log("Pressed Edit Save");
    const newEstablishment: CreateEstablishmentRequest = {
      id: uuidv4(),
      code: newAddEstablishmentCode,
      name: newAddEstablishmentName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      employees: [],
      establishmentProducts: [],
      establishmentServices: [],
    };

    console.log("Add Establishment request body: ", newEstablishment);

    const success = await AddEstablishment(newEstablishment);

    if (!success) {
      alert("Failed to add Establishment");
      return;
    }

    alert("Establishment added successfully");

    toggleAddEstablishmentModal();
    loadEstablishments();
    setNewAddEstablishmentCode("");
    setNewAddEstablishmentName("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedEstablishment) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedEstablishment.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteEstablishment(selectedEstablishment.id);

        if (!success) {
          alert("Failed to delete Establishment");
          return;
        }

        alert("Establishment deleted successfully");

        setExpandedRow(null);
        loadEstablishments();
      }
    }
  };

  const loadEstablishments = async () => {
    try {
      setLoading(true);
      const data = await fetchAllEstablishments();
      console.log("Retrieved from function loadEstablishments: ", data);
      setEstablishments(data);
    } catch (error) {
      console.error("Error loading establishments: ", error);
    } finally {
      setLoading(false);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadEstablishments();
  }, []);

  return (
    <>
      <h1 className="text-center mb-4">Establishments</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <EstablishmentTable
            establishments={establishments}
            paginatedEstablishments={paginatedEstablishments}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedEstablishment={selectedEstablishment}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(establishments.length / pageSize)}
          totalItems={establishments.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddEstablishmentModal}
          >
            Add Establishment
          </button>
        </div>
      </div>
      <EditEstablishmentModal
        showModal={showEditModal}
        toggleModal={toggleEditEstablishmentModal}
        newEstablishmentCode={newEditEstablishmentCode}
        newEstablishmentName={newEditEstablishmentName}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveEstablishment}
      />
      <AddEstablishmentModal
        showModal={showAddModal}
        toggleModal={toggleAddEstablishmentModal}
        newEstablishmentCode={newAddEstablishmentCode}
        newEstablishmentName={newAddEstablishmentName}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveEstablishment}
      />
    </>
  );
}

export default Establishment;
