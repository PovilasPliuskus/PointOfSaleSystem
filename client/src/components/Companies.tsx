import React, { useState, useEffect } from "react";
import Pagination from "./Pagination";
import "bootstrap/dist/css/bootstrap.min.css";

// Interface for initial company data
interface Company {
  id: string;
  name: string;
}

// Interface for detailed company information
interface CompanyDetails {
  code: string;
  establishments: any[];
  companyProducts: any[];
  companyServices: any[];
  id: string;
  name: string;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
}

function Companies() {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [companies, setCompanies] = useState<Company[]>([]);
  const [loading, setLoading] = useState(true);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedCompanyDetails, setSelectedCompanyDetails] =
    useState<CompanyDetails | null>(null);

  const totalItems = companies.length;
  const totalPages = Math.ceil(totalItems / pageSize);

  // Fetch initial companies list on page load
  useEffect(() => {
    const fetchCompanies = async () => {
      try {
        setLoading(true);
        const response = await fetch("https://localhost:44309/api/company", {
          method: "GET",
          credentials: "include",
        });
        const data = await response.json();
        setCompanies(data);
      } catch (error) {
        console.error("Error fetching companies:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchCompanies();
  }, []);

  // Handle row clicks to show detailed information
  const handleRowClick = async (index: number, companyId: string) => {
    setExpandedRow(expandedRow === index ? null : index);

    if (expandedRow !== index) {
      try {
        const response = await fetch(
          `https://localhost:44309/api/company/${companyId}`,
          {
            method: "GET",
            credentials: "include",
          }
        );

        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }

        const companyDetails = await response.json();
        console.log("Fetched company details:", companyDetails);
        setSelectedCompanyDetails(companyDetails);
      } catch (error) {
        console.error("Error fetching company details:", error);
      }
    }
  };

  // Edit action
  const handleEdit = () => {
    if (selectedCompanyDetails) {
      alert(`Editing company: ${selectedCompanyDetails.name}`);
    }
  };

  // Delete action
  const handleDelete = () => {
    if (selectedCompanyDetails) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedCompanyDetails.name}?`
      );
      if (confirmDelete) {
        alert(`Deleted company: ${selectedCompanyDetails.name}`);
        // Ideally, here you would call the delete API endpoint
      }
    }
  };

  const paginatedCompanies = companies.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  return (
    <>
      <h1 className="text-center mb-4">Companies</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <table className="table table-striped">
            <thead>
              <tr>
                <th scope="col">#</th>
                <th scope="col">Company Name</th>
              </tr>
            </thead>
            <tbody>
              {paginatedCompanies.map((company, index) => {
                const globalIndex = (currentPage - 1) * pageSize + index;
                return (
                  <React.Fragment key={company.id}>
                    {/* Clickable row */}
                    <tr
                      onClick={() => handleRowClick(globalIndex, company.id)}
                      style={{ cursor: "pointer" }}
                    >
                      <th scope="row">{globalIndex + 1}</th>
                      <td>{company.name}</td>
                    </tr>

                    {/* Expandable row with details and action buttons */}
                    {expandedRow === globalIndex && selectedCompanyDetails && (
                      <tr>
                        <td colSpan={2}>
                          <div className="border p-2">
                            <p>
                              <strong>Company Name:</strong>{" "}
                              {selectedCompanyDetails.name}
                            </p>
                            <p>
                              <strong>Code:</strong>{" "}
                              {selectedCompanyDetails.code}
                            </p>
                            <p>
                              <strong>Receive Time:</strong>{" "}
                              {new Date(
                                selectedCompanyDetails.receiveTime
                              ).toLocaleString()}
                            </p>
                            <p>
                              <strong>Update Time:</strong>{" "}
                              {new Date(
                                selectedCompanyDetails.updateTime
                              ).toLocaleString()}
                            </p>
                            <p>
                              <strong>Created By Employee ID:</strong>{" "}
                              {selectedCompanyDetails.createdByEmployeeId}
                            </p>
                            <p>
                              <strong>Modified By Employee ID:</strong>{" "}
                              {selectedCompanyDetails.modifiedByEmployeeId}
                            </p>
                            {/* Edit and Delete Buttons */}
                            <div className="mt-2">
                              <button
                                className="btn btn-warning me-2"
                                onClick={handleEdit}
                              >
                                Edit
                              </button>
                              <button
                                className="btn btn-danger"
                                onClick={handleDelete}
                              >
                                Delete
                              </button>
                            </div>
                          </div>
                        </td>
                      </tr>
                    )}
                  </React.Fragment>
                );
              })}
            </tbody>
          </table>
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={totalPages}
          totalItems={totalItems}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button className="btn btn-success btn-lg">Add Company</button>
        </div>
      </div>
    </>
  );
}

export default Companies;
