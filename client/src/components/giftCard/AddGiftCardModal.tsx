import { CurrencyDisplay } from "../../scripts/enums/CurrencyEnum";
import { FullOrderStatusEnum } from "../../scripts/enums/FullOrderStatusEnum";
import { FullOrderObject } from "../../scripts/interfaces";

interface AddGiftCardModalProps {
  showModal: boolean;
  newGiftCardName: string;
  newGiftCardAmount: number;
  newGiftCardCurrency: number;
  fullOrders: FullOrderObject[];

  toggleModal: () => void;
  handleInputChange: (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => void;
  handleSave: () => void;
}

const AddGiftCardModal: React.FC<AddGiftCardModalProps> = ({
  showModal,
  newGiftCardName,
  newGiftCardAmount,
  newGiftCardCurrency,
  fullOrders,
  toggleModal,
  handleInputChange,
  handleSave,
}) => {
  if (!showModal) return null;
  return (
    <div className="modal fade show" style={{ display: "block" }}>
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">Add New GiftCard</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">GiftCard Amount</label>
                <input
                  type="number"
                  className="form-control"
                  name="code"
                  value={newGiftCardAmount}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">GiftCard Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newGiftCardName}
                  onChange={handleInputChange}
                />
              </div>
              <div className="mb-3">
                <label className="form-label">Currency</label>
                <select
                  className="form-select"
                  name="currency"
                  value={newGiftCardCurrency}
                  onChange={handleInputChange}
                >
                  {Object.entries(CurrencyDisplay).map(([key, value]) => (
                    <option key={key} value={key}>
                      {value}
                    </option>
                  ))}
                </select>
                </div>
            </form>
          </div>
          <div className="mb-3">
            <label className="form-label">Select Full Order</label>
            <select
              className="form-select"
              name="fullOrderId"
              onChange={handleInputChange}
            >
              <option value="">Select an order</option>
              {fullOrders
                .filter(
                  (FullOrder) =>
                    FullOrder.status === FullOrderStatusEnum.Open
                )
                .map((fullOrder) => (
                  <option key={fullOrder.id} value={fullOrder.id}>
                    {fullOrder.name}
                  </option>
                ))}
            </select>
          </div>
          <div className="modal-footer">
            <button
              type="button"
              className="btn btn-secondary"
              onClick={toggleModal}
            >
              Close
            </button>
            <button
              type="button"
              className="btn btn-primary"
              onClick={handleSave}
            >
              Save Changes
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddGiftCardModal;
