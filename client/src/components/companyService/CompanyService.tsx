import { useEffect, useState } from "react";
import { v4 as uuidv4 } from "uuid";
import {
  CompanyObject,
  CompanyServiceObject,
  CreateCompanyServiceRequest,
  UpdateCompanyServiceRequest,
} from "../../scripts/interfaces";
import {
  AddCompanyService,
  DeleteCompanyService,
  fetchAllCompanyServices,
  fetchCompanyService,
  UpdateCompanyService,
} from "../../scripts/companyServiceFunctions";
import { fetchAllCompanies } from "../../scripts/companyFunctions";
import CompanyServiceTable from "./CompanyServiceTable";
import Pagination from "../Pagination";
import EditCompanyServiceModal from "./EditCompanyServiceModal";
import AddCompanyServiceModal from "./AddCompanyServiceModal";

function CompanyService() {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [companyServices, setCompanyServices] = useState<
    CompanyServiceObject[]
  >([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedCompanyService, setSelectedCompanyService] =
    useState<CompanyServiceObject | null>(null);
  const [companies, setCompanies] = useState<CompanyObject[]>([]);

  const paginatedCompanyServices = companyServices.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing CompanyService
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditCompanyServiceName, setNewEditCompanyServiceName] =
    useState("");

  // Used for Adding CompanyService
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddCompanyServiceName, setNewAddCompanyServiceName] = useState("");
  const [newCompanyId, setNewCompanyId] = useState("");

  // Functions
  const handleRowClick = async (index: number, companyServiceId: string) => {
    console.log("Pressed handleRowClick");

    if (expandedRow === index) {
      setExpandedRow(null);
      return;
    }

    if (expandedRow !== index) {
      try {
        const selectedCompanyService = await fetchCompanyService(
          companyServiceId
        );

        console.log(
          "Fetched selected company service details: ",
          selectedCompanyService
        );
        setSelectedCompanyService(selectedCompanyService);
        setExpandedRow(index);
      } catch (error) {
        console.error("Error fetching establishment service details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedCompanyService) {
      setShowEditModal(true);
      setNewEditCompanyServiceName(selectedCompanyService.name);
    }
  };

  const toggleEditCompanyServiceModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddCompanyServiceModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (type === "radio") {
    } else if (type === "text" || type === "number") {
      if (name === "name") setNewEditCompanyServiceName(value);
    }
  };

  const handleAddInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (name === "companyId") {
      setNewCompanyId(value);
      console.log(`VALUE = ${newCompanyId}`);
    }

    if (type === "radio") {
    } else if (type === "text" || type === "number") {
      if (name === "name") setNewAddCompanyServiceName(value);
    }
  };

  const handleEditSaveCompanyService = async () => {
    console.log("Pressed Edit Save");
    if (selectedCompanyService) {
      const updatedCompanyService: UpdateCompanyServiceRequest = {
        id: selectedCompanyService.id,
        name: newEditCompanyServiceName,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateCompanyService(updatedCompanyService);

      if (!success) {
        alert("Failed to update company service");
        return;
      }

      alert("company service updated successfully");

      toggleEditCompanyServiceModal();
      setExpandedRow(null);
      loadCompanyServices();
    }
  };

  const handleAddSaveCompanyServices = async () => {
    console.log("Pressed Edit Save");
    const newCompanyService: CreateCompanyServiceRequest = {
      id: uuidv4(),
      name: newAddCompanyServiceName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      fkCompanyId: newCompanyId,
    };

    console.log("Add company service request body: ", newCompanyService);

    const success = await AddCompanyService(newCompanyService);

    if (!success) {
      alert("Failed to add company service");
      return;
    }

    alert("Company service added successfully");

    toggleAddCompanyServiceModal();
    loadCompanyServices();
    setNewAddCompanyServiceName("");
    setNewCompanyId("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedCompanyService) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedCompanyService.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteCompanyService(selectedCompanyService.id);

        if (!success) {
          alert("Failed to delete company service");
          return;
        }

        alert("Company service deleted successfully");

        setExpandedRow(null);
        loadCompanyServices();
      }
    }
  };

  const loadCompanyServices = async () => {
    try {
      setLoading(true);
      const data = await fetchAllCompanyServices();
      console.log("Retrieved from function loadCompanyServices: ", data);
      setCompanyServices(data);
      const companies = await fetchAllCompanies();
      setCompanies(companies);
    } catch (error) {
      console.error("Error loading company services: ", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadCompanyServices();
  }, []);

  return (
    <>
      <h1 className="text-center mb-4">Company Services</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <CompanyServiceTable
            companyServices={companyServices}
            paginatedCompanyServices={paginatedCompanyServices}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedCompanyService={selectedCompanyService}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(companyServices.length / pageSize)}
          totalItems={companyServices.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddCompanyServiceModal}
          >
            Add Company Service
          </button>
        </div>
      </div>
      <EditCompanyServiceModal
        showModal={showEditModal}
        toggleModal={toggleEditCompanyServiceModal}
        newCompanyServiceName={newEditCompanyServiceName}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveCompanyService}
      />
      <AddCompanyServiceModal
        showModal={showAddModal}
        toggleModal={toggleAddCompanyServiceModal}
        newCompanyServiceName={newAddCompanyServiceName}
        companies={companies}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveCompanyServices}
      />
    </>
  );
}

export default CompanyService;
