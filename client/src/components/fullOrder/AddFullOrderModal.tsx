import { FullOrderStatusDisplay } from "../../scripts/enums/FullOrderStatusEnum";
import { EstablishmentObject } from "../../scripts/interfaces";

interface AddFullOrderModalProps {
  showModal: boolean;
  newFullOrderTip: number;
  newFullOrderStatus: number;
  newFullOrderName: string;
  establishments: EstablishmentObject[];

  toggleModal: () => void;
  handleInputChange: (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => void;
  handleSave: () => void;
}

const AddFullOrderModal: React.FC<AddFullOrderModalProps> = ({
  showModal,
  newFullOrderTip,
  newFullOrderStatus,
  newFullOrderName,
  establishments,
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
            <h5 className="modal-title">Add Full Order</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Add Order Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newFullOrderName}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Select Establishment</label>
                <select
                  className="form-select"
                  name="establishmentId"
                  onChange={handleInputChange}
                >
                  <option value="">Select establishment</option>
                  {establishments.map((establishment) => (
                    <option key={establishment.id} value={establishment.id}>
                      {establishment.name}
                    </option>
                  ))}
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">Full Order Status</label>
                <select
                  className="form-select"
                  name="status"
                  value={newFullOrderStatus}
                  onChange={handleInputChange}
                >
                  {Object.entries(FullOrderStatusDisplay).map(
                    ([key, value]) => (
                      <option key={key} value={key}>
                        {value}
                      </option>
                    )
                  )}
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">Add Order Tip</label>
                <input
                  type="number"
                  className="form-control"
                  name="tip"
                  value={newFullOrderTip}
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

export default AddFullOrderModal;
