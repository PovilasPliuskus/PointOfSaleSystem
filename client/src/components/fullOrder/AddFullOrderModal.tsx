interface AddFullOrderModalProps {
  showModal: boolean;
  newFullOrderTip: number;
  newFullOrderStatus: number;
  newFullOrderName: string;

  toggleModal: () => void;
  handleInputChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  handleSave: () => void;
}

const EditFullOrderModal: React.FC<AddFullOrderModalProps> = ({
  showModal,
  newFullOrderTip,
  newFullOrderStatus,
  newFullOrderName,
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
                <label className="form-label">Add Order Status</label>
                <input
                  type="text"
                  className="form-control"
                  name="status"
                  value={newFullOrderStatus}
                  onChange={handleInputChange}
                />
              </div>
              <div className="mb-3">
                <label className="form-label">Add Order Tip</label>
                <input
                  type="text"
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

export default EditFullOrderModal;
