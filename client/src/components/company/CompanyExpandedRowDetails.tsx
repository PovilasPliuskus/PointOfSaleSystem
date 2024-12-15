import React from "react";
import { CompanyObject } from "../../scripts/interfaces";

interface CompanyExpandedRowDetailsProps {
  selectedCompany: CompanyObject;
  onEdit: (compamyId: string) => void;
  onDelete: (compamyId: string) => void;
}

const CompanyExpendedRowDetails: React.FC<CompanyExpandedRowDetailsProps> = ({
  selectedCompany,
  onEdit,
  onDelete,
}) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>Company Name:</strong> {selectedCompany.name}
          </p>
          <p>
            <strong>Code:</strong> {selectedCompany.code}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedCompany.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedCompany.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedCompany.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedCompany.modifiedByEmployeeId}
          </p>
          <p>
            <strong>Establishments:</strong>{" "}
            {selectedCompany.establishments &&
            selectedCompany.establishments.length > 0 ? (
              <ul>
                {selectedCompany.establishments.map((est, idx) => (
                  <li key={idx}>{est.name}</li>
                ))}
              </ul>
            ) : (
              "No establishments"
            )}
          </p>
          <p>
            <strong>Company Products:</strong>{" "}
            {selectedCompany.companyProducts &&
            selectedCompany.companyProducts.length > 0 ? (
              <ul>
                {selectedCompany.companyProducts.map((prod, idx) => (
                  <li key={idx}>{prod.name}</li>
                ))}
              </ul>
            ) : (
              "No products"
            )}
          </p>
          <p>
            <strong>Company Services:</strong>{" "}
            {selectedCompany.companyServices &&
            selectedCompany.companyServices.length > 0 ? (
              <ul>
                {selectedCompany.companyServices.map((serv, idx) => (
                  <li key={idx}>{serv.name}</li>
                ))}
              </ul>
            ) : (
              "No services"
            )}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedCompany.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedCompany.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default CompanyExpendedRowDetails;
