import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css";

function Companies() {
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
            {Array.from({ length: 10 }).map((_, index) => (
              <React.Fragment key={index}>
                <tr
                  onClick={() => handleRowClick(index)}
                  style={{ cursor: "pointer" }}
                >
                  <th scope="row">{index + 1}</th>
                  <td>Company {index + 1}</td>
                </tr>
                {expandedRow === index && (
                  <tr>
                    <td colSpan={2} className="text-center">
                      <button className="btn btn-primary me-2">Update</button>
                      <button className="btn btn-danger">Delete</button>
                    </td>
                  </tr>
                )}
              </React.Fragment>
            ))}
          </tbody>
        </table>
        <div className="d-flex justify-content-end mt-3">
          <button className="btn btn-success btn-lg">Add Company</button>
        </div>
      </div>
    </>
  );
}

export default Companies;
