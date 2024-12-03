import React, { useState } from "react";
import Pagination from "./Pagination";
import "bootstrap/dist/css/bootstrap.min.css";

function Companies() {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const totalItems = 50; // Example total item count
  const totalPages = Math.ceil(totalItems / pageSize);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);

  const handleRowClick = (index: number) => {
    setExpandedRow(expandedRow === index ? null : index);
  };

  return (
    <>
      <h1 className="text-center mb-4">Companies</h1>
      <div className="container mt-4">
        <table className="table table-striped">
          <thead>
            <tr>
              <th scope="col">#</th>
              <th scope="col">Company Name</th>
            </tr>
          </thead>
          <tbody>
            {Array.from({ length: pageSize }).map((_, index) => {
              const globalIndex = (currentPage - 1) * pageSize + index;
              return (
                <React.Fragment key={globalIndex}>
                  <tr
                    onClick={() => handleRowClick(globalIndex)}
                    style={{ cursor: "pointer" }}
                  >
                    <th scope="row">{globalIndex + 1}</th>
                    <td>Company {globalIndex + 1}</td>
                  </tr>
                  {expandedRow === globalIndex && (
                    <tr>
                      <td colSpan={2} className="text-center">
                        <button className="btn btn-primary me-2">Update</button>
                        <button className="btn btn-danger">Delete</button>
                      </td>
                    </tr>
                  )}
                </React.Fragment>
              );
            })}
          </tbody>
        </table>
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
