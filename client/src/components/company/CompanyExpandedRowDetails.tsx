import React from "react";
import { CompanyDetails } from "./interfaces";

interface CompanyExpandedRowDetailsProps {
  companyDetails: CompanyDetails;
  onEdit: () => void;
  onDelete: () => void;
}

const CompanyExpendedRowDetails: React.FC<CompanyExpandedRowDetailsProps> = ({
  companyDetails,
  onEdit,
  onDelete,
}) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>Company Name:</strong> {companyDetails.name}
          </p>
          <p>
            <strong>Code:</strong> {companyDetails.code}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(companyDetails.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(companyDetails.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID:</strong>{" "}
            {companyDetails.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {companyDetails.modifiedByEmployeeId}
          </p>
          <p>
            <strong>Establishments:</strong>{" "}
            {companyDetails.establishments.length > 0 ? (
              <ul>
                {companyDetails.establishments.map((est, idx) => (
                  <li key={idx}>{est}</li>
                ))}
              </ul>
            ) : (
              "No establishments"
            )}
          </p>
          <p>
            <strong>Company Products:</strong>{" "}
            {companyDetails.companyProducts.length > 0 ? (
              <ul>
                {companyDetails.companyProducts.map((prod, idx) => (
                  <li key={idx}>{prod}</li>
                ))}
              </ul>
            ) : (
              "No products"
            )}
          </p>
          <p>
            <strong>Company Services:</strong>{" "}
            {companyDetails.companyServices.length > 0 ? (
              <ul>
                {companyDetails.companyServices.map((serv, idx) => (
                  <li key={idx}>{serv}</li>
                ))}
              </ul>
            ) : (
              "No services"
            )}
          </p>
          <div className="mt-2">
            <button className="btn btn-warning me-2" onClick={onEdit}>
              Edit
            </button>
            <button className="btn btn-danger" onClick={onDelete}>
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default CompanyExpendedRowDetails;
