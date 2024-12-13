import React from "react";

interface AddCompanyModalProps {
  showModal: boolean;
  toggleModal: () => void;
  handleSave: () => void;
  newCompanyCode: string;
  newCompanyName: string;
  handleInputChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  isEditMode: boolean;
}

const CompanyModal: React.FC<AddCompanyModalProps> = ({
  showModal,
  toggleModal,
  handleSave,
  newCompanyCode,
  newCompanyName,
  handleInputChange,
  isEditMode,
}) => {
  if (!showModal) return null;

  return (
    <div className="modal fade show" style={{ display: "block" }}>
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title">
              {isEditMode ? "Edit Company" : "Add New Company"}
            </h5>
            <button
              type="button"
              className="btn-close"
              onClick={toggleModal}
            ></button>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Company Code</label>
                <input
                  type="text"
                  className="form-control"
                  name="code"
                  value={newCompanyCode}
                  onChange={handleInputChange}
                />
              </div>
              <div className="mb-3">
                <label className="form-label">Company Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newCompanyName}
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

export default CompanyModal;
