interface EditCompanyProductModalProps {
  showModal: boolean;
  newCompanyProductName: string;
  newCompanyProductAlcoholicBeverage: boolean;

  toggleModal: () => void;
  handleInputChange: (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => void;
  handleSave: () => void;
}

const EditCompanyProductModal: React.FC<EditCompanyProductModalProps> = ({
  showModal,
  newCompanyProductName,
  newCompanyProductAlcoholicBeverage,
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
            <h5 className="modal-title">Edit Company Product</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newCompanyProductName}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Is Alcoholic Beverage</label>
                <div>
                  <input
                    type="radio"
                    id="alcoholic-yes"
                    name="alcoholicBeverage"
                    value="true"
                    checked={newCompanyProductAlcoholicBeverage === true}
                    onChange={handleInputChange}
                  />
                  <label htmlFor="alcoholic-yes" className="form-check-label">
                    Yes
                  </label>
                </div>
                <div>
                  <input
                    type="radio"
                    id="alcoholic-no"
                    name="alcoholicBeverage"
                    value="false"
                    checked={newCompanyProductAlcoholicBeverage === false}
                    onChange={handleInputChange}
                  />
                  <label htmlFor="alcoholic-no" className="form-check-label">
                    No
                  </label>
                </div>
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

export default EditCompanyProductModal;
