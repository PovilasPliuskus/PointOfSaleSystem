import { FullOrderStatusEnum } from "../../scripts/enums/FullOrderStatusEnum";
import { FullOrderObject } from "../../scripts/interfaces";

interface AddTaxModalProps {
  showModal: boolean;
  newTaxName: string;
  newTaxAmount: number;
  fullOrders: FullOrderObject[];

  toggleModal: () => void;
  handleInputChange: (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => void;
  handleSave: () => void;
}

const AddTaxModal: React.FC<AddTaxModalProps> = ({
  showModal,
  newTaxName,
  newTaxAmount,
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
            <h5 className="modal-title">Add New Tax</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Tax Amount</label>
                <input
                  type="number"
                  className="form-control"
                  name="code"
                  value={newTaxAmount}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Tax Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newTaxName}
                  onChange={handleInputChange}
                />
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

export default AddTaxModal;
