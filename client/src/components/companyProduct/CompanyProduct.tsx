import { useEffect, useState } from "react";
import { v4 as uuidv4 } from "uuid";
import {
  CompanyObject,
  CompanyProductObject,
  CreateCompanyProductRequest,
  UpdateCompanyProductRequest,
} from "../../scripts/interfaces";
import {
  AddCompanyProduct,
  DeleteCompanyProduct,
  fetchAllCompanyProducts,
  fetchCompanyProduct,
  UpdateCompanyProduct,
} from "../../scripts/companyProductFunctions";
import { fetchAllCompanies } from "../../scripts/companyFunctions";
import CompanyProductTable from "./CompanyProductTable";
import Pagination from "../Pagination";
import EditCompanyProductModal from "./EditCompanyProductModal";
import AddCompanyProductModal from "./AddCompanyProductModal";

function CompanyProduct() {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [companyProducts, setCompanyProducts] = useState<
    CompanyProductObject[]
  >([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedCompanyProduct, setSelectedCompanyProduct] =
    useState<CompanyProductObject | null>(null);
  const [companies, setCompanies] = useState<CompanyObject[]>([]);

  const paginatedCompanyProducts = companyProducts.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing CompanyProduct
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditCompanyProductName, setNewEditCompanyProductName] =
    useState("");
  const [
    newEditCompanyProductAlcoholicBeverage,
    setNewEditCompanyProductAlcoholicBeverage,
  ] = useState(false);

  // Used for Adding CompanyProduct
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddCompanyProductName, setNewAddCompanyProductName] = useState("");
  const [
    newAddCompanyProductAlcoholicBeverage,
    setNewAddCompanyProductAlcoholicBeverage,
  ] = useState(false);
  const [newCompanyId, setNewCompanyId] = useState("");

  // Functions
  const handleRowClick = async (index: number, companyProductId: string) => {
    console.log("Pressed handleRowClick");

    if (expandedRow === index) {
      setExpandedRow(null);
      return;
    }

    if (expandedRow !== index) {
      try {
        const selectedCompanyProduct = await fetchCompanyProduct(
          companyProductId
        );

        console.log(
          "Fetched selected company product details: ",
          selectedCompanyProduct
        );
        setSelectedCompanyProduct(selectedCompanyProduct);
        setExpandedRow(index);
      } catch (error) {
        console.error("Error fetching establishment product details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedCompanyProduct) {
      setShowEditModal(true);
      setNewEditCompanyProductName(selectedCompanyProduct.name);
      setNewEditCompanyProductAlcoholicBeverage(
        selectedCompanyProduct.alcoholicBeverage
      );
    }
  };

  const toggleEditCompanyProductModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddCompanyProductModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (type === "radio") {
      if (name === "alcoholicBeverage")
        setNewEditCompanyProductAlcoholicBeverage(value === "true");
    } else if (type === "text" || type === "number") {
      if (name === "name") setNewEditCompanyProductName(value);
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
      if (name === "alcoholicBeverage") {
        setNewAddCompanyProductAlcoholicBeverage(value === "true");
      }
    } else if (type === "text" || type === "number") {
      if (name === "name") setNewAddCompanyProductName(value);
    }
  };

  const handleEditSaveCompanyProduct = async () => {
    console.log("Pressed Edit Save");
    if (selectedCompanyProduct) {
      const updatedCompanyProduct: UpdateCompanyProductRequest = {
        id: selectedCompanyProduct.id,
        name: newEditCompanyProductName,
        alcoholicBeverage: newEditCompanyProductAlcoholicBeverage,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateCompanyProduct(updatedCompanyProduct);

      if (!success) {
        alert("Failed to update company product");
        return;
      }

      alert("company product updated successfully");

      toggleEditCompanyProductModal();
      setExpandedRow(null);
      loadCompanyProducts();
    }
  };

  const handleAddSaveCompanyProducts = async () => {
    console.log("Pressed Edit Save");
    const newCompanyProduct: CreateCompanyProductRequest = {
      id: uuidv4(),
      name: newAddCompanyProductName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      alcoholicBeverage: newAddCompanyProductAlcoholicBeverage,
      fkCompanyId: newCompanyId,
    };

    console.log("Add company product request body: ", newCompanyProduct);

    const success = await AddCompanyProduct(newCompanyProduct);

    if (!success) {
      alert("Failed to add company product");
      return;
    }

    alert("Company product added successfully");

    toggleAddCompanyProductModal();
    loadCompanyProducts();
    setNewAddCompanyProductName("");
    setNewAddCompanyProductAlcoholicBeverage(false);
    setNewCompanyId("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedCompanyProduct) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedCompanyProduct.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteCompanyProduct(selectedCompanyProduct.id);

        if (!success) {
          alert("Failed to delete company product");
          return;
        }

        alert("Company product deleted successfully");

        setExpandedRow(null);
        loadCompanyProducts();
      }
    }
  };

  const loadCompanyProducts = async () => {
    try {
      setLoading(true);
      const data = await fetchAllCompanyProducts();
      console.log("Retrieved from function loadCompanyProducts: ", data);
      setCompanyProducts(data);
      const companies = await fetchAllCompanies();
      setCompanies(companies);
    } catch (error) {
      console.error("Error loading company products: ", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    loadCompanyProducts();
  }, []);

  return (
    <>
      <h1 className="text-center mb-4">Company Products</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <CompanyProductTable
            companyProducts={companyProducts}
            paginatedCompanyProducts={paginatedCompanyProducts}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedCompanyProduct={selectedCompanyProduct}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(companyProducts.length / pageSize)}
          totalItems={companyProducts.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddCompanyProductModal}
          >
            Add Company Product
          </button>
        </div>
      </div>
      <EditCompanyProductModal
        showModal={showEditModal}
        toggleModal={toggleEditCompanyProductModal}
        newCompanyProductName={newEditCompanyProductName}
        newCompanyProductAlcoholicBeverage={
          newEditCompanyProductAlcoholicBeverage
        }
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveCompanyProduct}
      />
      <AddCompanyProductModal
        showModal={showAddModal}
        toggleModal={toggleAddCompanyProductModal}
        newCompanyProductName={newAddCompanyProductName}
        newCompanyProductAlcoholicBeverage={
          newAddCompanyProductAlcoholicBeverage
        }
        companies={companies}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveCompanyProducts}
      />
    </>
  );
}

export default CompanyProduct;
