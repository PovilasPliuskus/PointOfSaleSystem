import { useEffect, useState } from "react";
import { fetchFullOrder } from "../../scripts/fullOrderFunctions";
import { FullOrderObject, OrderObject } from "../../scripts/interfaces";

interface OrderExpandedRowDetailsProps {
  selectedOrder: OrderObject;
  onEdit: (orderId: string) => void;
  onDelete: (orderId: string) => void;
}

const OrderExpandedRowDetails: React.FC<OrderExpandedRowDetailsProps> = ({
  selectedOrder,
  onEdit,
  onDelete,
}) => {
  const [fullOrder, setFullOrder] = useState<FullOrderObject | null>(null);

  useEffect(() => {
    const fetchOrder = async () => {
      setFullOrder(null);
      const result = await fetchFullOrder(selectedOrder.fullOrderId);
      setFullOrder(result);
    };
    fetchOrder();
  }, [selectedOrder.fullOrderId]);

  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>Order Name:</strong> {selectedOrder.name}
          </p>
          <p>
            <strong>Count:</strong> {selectedOrder.count}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedOrder.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedOrder.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedOrder.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedOrder.modifiedByEmployeeId}
          </p>
          <p>
            <strong>Establishment Service ID:</strong>{" "}
            {selectedOrder.establishmentServiceId}
          </p>
          <p>
            <strong>Establishment Product ID:</strong>{" "}
            {selectedOrder.establishmentProductId}
          </p>
          <p>
            <strong>FullOrder:</strong> {fullOrder?.name || "Loading..."}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedOrder.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedOrder.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default OrderExpandedRowDetails;
