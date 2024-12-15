interface AddEstablishmentModalProps {
  showModal: boolean;
  newEstablishmentName: string;
  newEstablishmentCode: string;

  toggleModal: () => void;
  handleInputChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  handleSave: () => void;
}

const AddEstablishmentModal: React.FC<AddEstablishmentModalProps> = ({
  showModal,
  newEstablishmentName,
  newEstablishmentCode,
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
            <h5 className="modal-title">Add New Establishment</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Establishment Code</label>
                <input
                  type="text"
                  className="form-control"
                  name="code"
                  value={newEstablishmentCode}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Establishment Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newEstablishmentName}
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

export default AddEstablishmentModal;
