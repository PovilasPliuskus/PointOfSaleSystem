import React from "react";
import { TaxObject } from "../../scripts/interfaces";

interface TaxExpandedRowDetailsProps {
  selectedTax: TaxObject;
  onEdit: (taxId: string) => void;
  onDelete: (taxId: string) => void;
}

const TaxExpendedRowDetails: React.FC<TaxExpandedRowDetailsProps> = ({
  selectedTax,
  onEdit,
  onDelete,
}) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>Tax Name:</strong> {selectedTax.name}
          </p>
          <p>
            <strong>Amount:</strong> {selectedTax.amount}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedTax.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedTax.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedTax.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedTax.modifiedByEmployeeId}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedTax.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedTax.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default TaxExpendedRowDetails;
