import { useEffect, useState } from "react";
import { CompanyObject, UpdateCompanyRequest } from "../../scripts/interfaces";
import CompanyTable from "./CompanyTable";
import Pagination from "../Pagination";
import {
  AddCompany,
  DeleteCompany,
  fetchAllCompanies,
  fetchCompany,
  UpdateCompany,
} from "../../scripts/companyFunctions";
import EditCompanyModal from "./EditCompanyModal";
import AddCompanyModal from "./AddCompanyModal";
import { v4 as uuidv4 } from "uuid";
import Navbar from "../Navbar";

function Company() {
  // Variables
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [companies, setCompanies] = useState<CompanyObject[]>([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedCompany, setSelectedCompany] = useState<CompanyObject | null>(
    null
  );

  const paginatedCompanies = companies.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing Company
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditCompanyCode, setNewEditCompanyCode] = useState("");
  const [newEditCompanyName, setNewEditCompanyName] = useState("");

  // Used for Adding Company
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddCompanyCode, setNewAddCompanyCode] = useState("");
  const [newAddCompanyName, setNewAddCompanyName] = useState("");

  // Functions
  const handleRowClick = async (index: number, companyId: string) => {
    console.log("Pressed handleRowClick");

    setExpandedRow(expandedRow === index ? null : index);

    if (expandedRow !== index) {
      try {
        const selectedCompany = await fetchCompany(companyId);

        console.log("Fetched selected company details: ", selectedCompany);
        setSelectedCompany(selectedCompany);
      } catch (error) {
        console.error("Error fetching company details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedCompany) {
      setShowEditModal(true);
      setNewEditCompanyName(selectedCompany.name);
      setNewEditCompanyCode(selectedCompany.code);
    }
  };

  const toggleEditCompanyModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddCompanyModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    if (name === "code") setNewEditCompanyCode(value);
    if (name === "name") setNewEditCompanyName(value);
  };

  const handleAddInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    if (name === "code") setNewAddCompanyCode(value);
    if (name === "name") setNewAddCompanyName(value);
  };

  const handleEditSaveCompany = async () => {
    console.log("Pressed Edit Save");
    if (selectedCompany) {
      const updatedCompany: UpdateCompanyRequest = {
        id: selectedCompany.id,
        code: newEditCompanyCode,
        name: newEditCompanyName,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateCompany(updatedCompany);

      if (!success) {
        alert("Failed to update company");
        return;
      }

      alert("Company updated successfully");

      toggleEditCompanyModal();
      setExpandedRow(null);
      loadCompanies();
    }
  };

  const handleAddSaveCompany = async () => {
    console.log("Pressed Edit Save");
    const newCompany: CompanyObject = {
      id: uuidv4(),
      code: newAddCompanyCode,
      name: newAddCompanyName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      establishments: [],
      companyProducts: [],
      companyServices: [],
    };

    console.log("Add Company request body: ", newCompany);

    const success = await AddCompany(newCompany);

    if (!success) {
      alert("Failed to add company");
      return;
    }

    alert("Company added successfully");

    toggleAddCompanyModal();
    loadCompanies();
    setNewAddCompanyCode("");
    setNewAddCompanyName("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedCompany) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedCompany.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteCompany(selectedCompany.id);

        if (!success) {
          alert("Failed to delete company");
          return;
        }

        alert("Company deleted successfully");

        setExpandedRow(null);
        loadCompanies();
      }
    }
  };

  const loadCompanies = async () => {
    try {
      setLoading(true);
      const data = await fetchAllCompanies();
      console.log("Retrieved from function loadCompanies: ", data);
      setCompanies(data);
    } catch (error) {
      console.error("Error loading companies: ", error);
    } finally {
      setLoading(false);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadCompanies();
  }, []);

  return (
    <>
      <Navbar />
      <h1 className="text-center mb-4">Companies</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <CompanyTable
            companies={companies}
            paginatedCompanies={paginatedCompanies}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedCompany={selectedCompany}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(companies.length / pageSize)}
          totalItems={companies.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddCompanyModal}
          >
            Add Company
          </button>
        </div>
      </div>
      <EditCompanyModal
        showModal={showEditModal}
        toggleModal={toggleEditCompanyModal}
        newCompanyCode={newEditCompanyCode}
        newCompanyName={newEditCompanyName}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveCompany}
      />
      <AddCompanyModal
        showModal={showAddModal}
        toggleModal={toggleAddCompanyModal}
        newCompanyCode={newAddCompanyCode}
        newCompanyName={newAddCompanyName}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveCompany}
      />
    </>
  );
}

export default Company;
