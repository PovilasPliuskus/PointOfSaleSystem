import React, { useState, useEffect } from "react";
import Pagination from "./Pagination";
import "bootstrap/dist/css/bootstrap.min.css";

interface Company {
  id: string;
  name: string;
  code: string;
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

  const totalItems = companies.length;
  const totalPages = Math.ceil(totalItems / pageSize);

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

  const handleRowClick = (index: number) => {
    setExpandedRow(expandedRow === index ? null : index);
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
                    <tr
                      onClick={() => handleRowClick(globalIndex)}
                      style={{ cursor: "pointer" }}
                    >
                      <th scope="row">{globalIndex + 1}</th>
                      <td>{company.name}</td>
                    </tr>
                    {expandedRow === globalIndex && (
                      <tr>
                        <td colSpan={2} className="text-center">
                          <button className="btn btn-primary me-2">
                            Update
                          </button>
                          <button className="btn btn-danger">Delete</button>
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
