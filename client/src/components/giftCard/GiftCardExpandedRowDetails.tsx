import React, { useEffect, useState } from "react";
import { FullOrderObject, GiftCardObject } from "../../scripts/interfaces";
import { getCurrencyDisplay } from "../../scripts/enums/CurrencyEnum";
import { fetchFullOrder } from "../../scripts/fullOrderFunctions";

interface GiftCardExpandedRowDetailsProps {
  selectedGiftCard: GiftCardObject;
  onEdit: (giftCardId: string) => void;
  onDelete: (giftCardId: string) => void;
}

const GiftCardExpendedRowDetails: React.FC<GiftCardExpandedRowDetailsProps> = ({
  selectedGiftCard,
  onEdit,
  onDelete,
}) => {

  /*const [fullOrder, setFullOrder] = useState<FullOrderObject | null>(null);
  
  useEffect(() => {
    const fetchOrder = async () => {
      setFullOrder(null);
      const result = await fetchFullOrder(selectedGiftCard.fkGiftFullOrderId);
      setFullOrder(result);
    };
    fetchOrder();
  }, [selectedGiftCard.fkGiftFullOrderId]);*/

  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>GiftCard Name:</strong> {selectedGiftCard.name}
          </p>
          <p>
            <strong>Amount:</strong> {selectedGiftCard.amount}
          </p>
          <p>
            <strong>Currency:</strong>{" "}
            {getCurrencyDisplay(selectedGiftCard.currency)}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedGiftCard.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedGiftCard.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedGiftCard.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedGiftCard.modifiedByEmployeeId}
          </p>
          <p>
            <strong>FullOrder gift card is applied to:</strong> {selectedGiftCard?.fkGiftFullOrderId || "Loading..."}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedGiftCard.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedGiftCard.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default GiftCardExpendedRowDetails;
