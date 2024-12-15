import React from "react";
import { EstablishmentProductObject } from "../../scripts/interfaces";
import { getCurrencyDisplay } from "../../scripts/enums/CurrencyEnum";

interface EstablishmentProductExpandedRowDetailsProps {
  selectedEstablishmentProduct: EstablishmentProductObject;
  onEdit: (establishmentProductId: string) => void;
  onDelete: (establishmentProductId: string) => void;
}

const EstablishmentProductExpandedRowDetails: React.FC<
  EstablishmentProductExpandedRowDetailsProps
> = ({ selectedEstablishmentProduct, onEdit, onDelete }) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>EstablishmentProduct Name:</strong>{" "}
            {selectedEstablishmentProduct.name}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(
              selectedEstablishmentProduct.receiveTime
            ).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedEstablishmentProduct.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedEstablishmentProduct.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedEstablishmentProduct.modifiedByEmployeeId}
          </p>
          <p>
            <strong>Price:</strong> {selectedEstablishmentProduct.price}
          </p>
          <p>
            <strong>Amount in stock:</strong>{" "}
            {selectedEstablishmentProduct.amountInStock}
          </p>
          <p>
            <strong>Currency:</strong>{" "}
            {getCurrencyDisplay(selectedEstablishmentProduct.currency)}
          </p>
          <p>
            <strong>In Orders:</strong>{" "}
            {selectedEstablishmentProduct.orders &&
            selectedEstablishmentProduct.orders.length > 0 ? (
              <ul>
                {selectedEstablishmentProduct.orders.map((est, idx) => (
                  <li key={idx}>{est.name}</li>
                ))}
              </ul>
            ) : (
              "No orders have this product"
            )}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedEstablishmentProduct.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedEstablishmentProduct.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default EstablishmentProductExpandedRowDetails;
