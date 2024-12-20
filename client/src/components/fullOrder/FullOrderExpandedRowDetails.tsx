import { FullOrderObject } from "../../scripts/interfaces";
import { getFullOrderStatusDisplay } from "../../scripts/enums/FullOrderStatusEnum";

interface FullOrderExpandedRowDetailsProps {
  selectedFullOrder: FullOrderObject;
  onEdit: (fullOrderId: string) => void;
  onDelete: (fullOrderId: string) => void;
  onCheckout: (fullOrderId: string) => void;
}

const FullOrderExpandedRowDetails: React.FC<
  FullOrderExpandedRowDetailsProps
> = ({ selectedFullOrder, onEdit, onDelete, onCheckout}) => {
  return (
    <tr>
      <td colSpan={5}>
        <div className="border p-2">
          <p>
            <strong>Name:</strong> {selectedFullOrder.name}
          </p>
          <p>
            <strong>Status:</strong>{" "}
            {getFullOrderStatusDisplay(selectedFullOrder.status)}
          </p>
          <p>
            <strong>Tip:</strong> {selectedFullOrder.tip}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedFullOrder.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedFullOrder.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedFullOrder.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedFullOrder.modifiedByEmployeeId}
          </p>
          <p>
            <strong>Orders:</strong>{" "}
            {selectedFullOrder.orders && selectedFullOrder.orders.length > 0 ? (
              <ul>
                {selectedFullOrder.orders.map((order, idx) => (
                  <li key={idx}>{order.name}</li>
                ))}
              </ul>
            ) : (
              "No orders"
            )}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedFullOrder.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger me-2"
              onClick={() => onDelete(selectedFullOrder.id)}
            >
              Delete
            </button>
            <button
              className="btn btn-primary"
              onClick={() => onCheckout(selectedFullOrder.id)}
            >
              Checkout
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default FullOrderExpandedRowDetails;
