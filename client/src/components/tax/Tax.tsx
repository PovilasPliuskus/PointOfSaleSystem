import { useEffect, useState } from "react";
import { TaxObject, UpdateTaxRequest } from "../../scripts/interfaces";
import TaxTable from "./TaxTable";
import Pagination from "../Pagination";
import {
  AddTax,
  DeleteTax,
  fetchAllTaxes,
  fetchTax,
  UpdateTax,
} from "../../scripts/taxFunctions";
import EditTaxModal from "./EditTaxModal";
import AddTaxModal from "./AddTaxModal";
import { v4 as uuidv4 } from "uuid";
import Navbar from "../Navbar";

function Tax() {
  // Variables
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [taxes, setTaxes] = useState<TaxObject[]>([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedTax, setSelectedTax] = useState<TaxObject | null>(
    null
  );

  const paginatedTaxes = taxes.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing Tax
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditTaxAmount, setnewEditTaxAmount] = useState(0.0);
  const [newEditTaxName, setNewEditTaxName] = useState("");

  // Used for Adding Tax
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddTaxAmount, setnewAddTaxAmount] = useState(0.0);
  const [newAddTaxName, setNewAddTaxName] = useState("");

  // Functions
  const handleRowClick = async (index: number, taxId: string) => {
    console.log("Pressed handleRowClick");

    setExpandedRow(expandedRow === index ? null : index);

    if (expandedRow !== index) {
      try {
        const selectedTax = await fetchTax(taxId);

        console.log("Fetched selected tax details: ", selectedTax);
        setSelectedTax(selectedTax);
      } catch (error) {
        console.error("Error fetching tax details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedTax) {
      setShowEditModal(true);
      setNewEditTaxName(selectedTax.name);
      setnewEditTaxAmount(selectedTax.amount);
    }
  };

  const toggleEditTaxModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddTaxModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    if (name === "code") setnewEditTaxAmount(parseFloat(value));
    if (name === "name") setNewEditTaxName(value);
  };

  const handleAddInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    if (name === "code") setnewAddTaxAmount(parseFloat(value));
    if (name === "name") setNewAddTaxName(value);
  };

  const handleEditSaveTax = async () => {
    console.log("Pressed Edit Save");
    if (selectedTax) {
      const updatedTax: UpdateTaxRequest = {
        id: selectedTax.id,
        amount: newEditTaxAmount,
        name: newEditTaxName,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateTax(updatedTax);

      if (!success) {
        alert("Failed to update tax");
        return;
      }

      alert("Tax updated successfully");

      toggleEditTaxModal();
      setExpandedRow(null);
      loadTaxes();
    }
  };

  const handleAddSaveTax = async () => {
    console.log("Pressed Edit Save");
    const newTax: TaxObject = {
      id: uuidv4(),
      amount: newAddTaxAmount,
      name: newAddTaxName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000"
    };

    console.log("Add Tax request body: ", newTax);

    const success = await AddTax(newTax);

    if (!success) {
      alert("Failed to add tax");
      return;
    }

    alert("Tax added successfully");

    toggleAddTaxModal();
    loadTaxes();
    setnewAddTaxAmount(0.0);
    setNewAddTaxName("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedTax) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedTax.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteTax(selectedTax.id);

        if (!success) {
          alert("Failed to delete tax");
          return;
        }

        alert("Tax deleted successfully");

        setExpandedRow(null);
        loadTaxes();
      }
    }
  };

  const loadTaxes = async () => {
    try {
      setLoading(true);
      const data = await fetchAllTaxes();
      console.log("Retrieved from function loadTaxes: ", data);
      setTaxes(data);
    } catch (error) {
      console.error("Error loading taxes: ", error);
    } finally {
      setLoading(false);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadTaxes();
  }, []);

  return (
    <>
      <Navbar />
      <h1 className="text-center mb-4">Taxes</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <TaxTable
            taxes={taxes}
            paginatedTaxes={paginatedTaxes}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedTax={selectedTax}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(taxes.length / pageSize)}
          totalItems={taxes.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddTaxModal}
          >
            Add Tax
          </button>
        </div>
      </div>
      <EditTaxModal
        showModal={showEditModal}
        toggleModal={toggleEditTaxModal}
        newTaxCode={newEditTaxAmount}
        newTaxName={newEditTaxName}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveTax}
      />
      <AddTaxModal
        showModal={showAddModal}
        toggleModal={toggleAddTaxModal}
        newTaxCode={newAddTaxAmount}
        newTaxName={newAddTaxName}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveTax}
      />
    </>
  );
}

export default Tax;
