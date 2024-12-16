import { getCurrencyDisplay } from "../../scripts/enums/CurrencyEnum";
import { EstablishmentServiceObject } from "../../scripts/interfaces";

interface EstablishmentServiceExpandedRowDetailsProps {
  selectedEstablishmentService: EstablishmentServiceObject;
  onEdit: (establishmentServiceId: string) => void;
  onDelete: (establishmentServiceId: string) => void;
}

const EstablishmentServiceExpandedRowDetails: React.FC<
  EstablishmentServiceExpandedRowDetailsProps
> = ({ selectedEstablishmentService, onEdit, onDelete }) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>EstablishmentProduct Name:</strong>{" "}
            {selectedEstablishmentService.name}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(
              selectedEstablishmentService.receiveTime
            ).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedEstablishmentService.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedEstablishmentService.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedEstablishmentService.modifiedByEmployeeId}
          </p>
          <p>
            <strong>Price:</strong> {selectedEstablishmentService.price}
          </p>
          <p>
            <strong>Currency:</strong>{" "}
            {getCurrencyDisplay(selectedEstablishmentService.currency)}
          </p>
          <p>
            <strong>In Orders:</strong>{" "}
            {selectedEstablishmentService.orders &&
            selectedEstablishmentService.orders.length > 0 ? (
              <ul>
                {selectedEstablishmentService.orders.map((est, idx) => (
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
              onClick={() => onEdit(selectedEstablishmentService.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedEstablishmentService.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default EstablishmentServiceExpandedRowDetails;
