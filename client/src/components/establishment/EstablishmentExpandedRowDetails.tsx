import React from "react";
import { EstablishmentObject } from "../../scripts/interfaces";

interface EstablishmentExpandedRowDetailsProps {
  selectedEstablishment: EstablishmentObject;
  onEdit: (establishmentId: string) => void;
  onDelete: (establishmentId: string) => void;
}

const EstablishmentExpandedRowDetails: React.FC<
  EstablishmentExpandedRowDetailsProps
> = ({ selectedEstablishment, onEdit, onDelete }) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>Name:</strong> {selectedEstablishment.name}
          </p>
          <p>
            <strong>Code:</strong> {selectedEstablishment.code}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedEstablishment.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedEstablishment.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedEstablishment.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedEstablishment.modifiedByEmployeeId}
          </p>
          <p>
            <strong>Employees:</strong>{" "}
            {selectedEstablishment.employees &&
            selectedEstablishment.employees.length > 0 ? (
              <ul>
                {selectedEstablishment.employees.map((prod, idx) => (
                  <li key={idx}>{prod.name}</li>
                ))}
              </ul>
            ) : (
              "No products"
            )}
          </p>
          <p>
            <strong>Establishment Products:</strong>{" "}
            {selectedEstablishment.establishmentProducts &&
            selectedEstablishment.establishmentProducts.length > 0 ? (
              <ul>
                {selectedEstablishment.establishmentProducts.map(
                  (prod, idx) => (
                    <li key={idx}>{prod.name}</li>
                  )
                )}
              </ul>
            ) : (
              "No products"
            )}
          </p>
          <p>
            <strong>Establishment Services:</strong>{" "}
            {selectedEstablishment.establishmentServices &&
            selectedEstablishment.establishmentServices.length > 0 ? (
              <ul>
                {selectedEstablishment.establishmentServices.map(
                  (serv, idx) => (
                    <li key={idx}>{serv.name}</li>
                  )
                )}
              </ul>
            ) : (
              "No services"
            )}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedEstablishment.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedEstablishment.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default EstablishmentExpandedRowDetails;
