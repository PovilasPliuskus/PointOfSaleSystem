import { useEffect, useState } from "react";
import { Company } from "./company/interfaces";
import CompanyTable from "./company/CompanyTable";
import Pagination from "./Pagination";
import { fetchAllCompanies, fetchCompany } from "../scripts/companyFunctions";

function CleanCompany() {
  // Variables
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [companies, setCompanies] = useState<Company[]>([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedCompany, setSelectedCompany] = useState<Company | null>(null);

  const paginatedCompanies = companies.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

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
  };

  const handleDeleteClick = () => {
    console.log("Pressed handleDeleteClick");
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
      </div>
    </>
  );
}

export default CleanCompany;
