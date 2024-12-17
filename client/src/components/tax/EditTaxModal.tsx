interface EditTaxModalProps {
  showModal: boolean;
  newTaxAmount: number;
  newTaxName: string;

  toggleModal: () => void;
  handleInputChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  handleSave: () => void;
}

const EditTaxModal: React.FC<EditTaxModalProps> = ({
  showModal,
  newTaxAmount,
  newTaxName,
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
            <h5 className="modal-title">Edit Tax</h5>
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

export default EditTaxModal;
