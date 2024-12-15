import { FullOrderStatusEnum } from "../../scripts/enums/FullOrderStatusEnum";
import { FullOrderObject } from "../../scripts/interfaces";

interface AddOrderModalProps {
  showModal: boolean;
  newOrderName: string;
  newOrderCount: number;
  fullOrders: FullOrderObject[];

  toggleModal: () => void;
  handleInputChange: (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => void;
  handleSave: () => void;
}

const AddOrderModal: React.FC<AddOrderModalProps> = ({
  showModal,
  newOrderName,
  newOrderCount,
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
            <h5 className="modal-title">Add New Order</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newOrderName}
                  onChange={handleInputChange}
                />
              </div>
              <div className="mb-3">
                <label className="form-label">Select Full Order</label>
                <select
                  className="form-select"
                  name="fullOrderId"
                  onChange={handleInputChange}
                >
                  <option value="">Select and order</option>
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
              <div className="mb-3">
                <label className="form-label">Count</label>
                <input
                  type="number"
                  className="form-control"
                  name="count"
                  value={newOrderCount}
                  onChange={handleInputChange}
                />
              </div>
            </form>
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

export default AddOrderModal;
