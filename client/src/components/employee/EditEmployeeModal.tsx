import { EmployeeStatusDisplay } from "../../scripts/enums/EmployeeStatus";

interface EditEmployeeModalProps {
  showModal: boolean;
  newEmployeeSurname: string;
  newEmployeeSalary: number;
  newEmployeeStatus: number;
  newEmployeeLoginUsername: string;
  newEmployeeLoginPasswordHashed: string;
  newEmployeeName: string;

  toggleModal: () => void;
  handleInputChange: (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => void;
  handleSave: () => void;
}

const EditEmployeeModal: React.FC<EditEmployeeModalProps> = ({
  showModal,
  newEmployeeSurname,
  newEmployeeSalary,
  newEmployeeStatus,
  newEmployeeLoginUsername,
  newEmployeeLoginPasswordHashed,
  newEmployeeName,
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
            <h5 className="modal-title">Edit Employee</h5>
          </div>
          <div className="modal-body">
            <form>
              <div className="mb-3">
                <label className="form-label">Name</label>
                <input
                  type="text"
                  className="form-control"
                  name="name"
                  value={newEmployeeName}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Surname</label>
                <input
                  type="text"
                  className="form-control"
                  name="surname"
                  value={newEmployeeSurname}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Employee Status</label>
                <select
                  className="form-select"
                  name="employeeStatus"
                  value={newEmployeeStatus}
                  onChange={handleInputChange}
                >
                  {Object.entries(EmployeeStatusDisplay).map(([key, value]) => (
                    <option key={key} value={key}>
                      {value}
                    </option>
                  ))}
                </select>
              </div>
              <div className="mb-3">
                <label className="form-label">Salary</label>
                <input
                  type="number"
                  className="form-control"
                  name="salary"
                  value={newEmployeeSalary}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Username</label>
                <input
                  type="text"
                  className="form-control"
                  name="loginUsername"
                  value={newEmployeeLoginUsername}
                  onChange={handleInputChange}
                ></input>
              </div>
              <div className="mb-3">
                <label className="form-label">Password</label>
                <input
                  type="password"
                  className="form-control"
                  name="loginPasswordHashed"
                  value={newEmployeeLoginPasswordHashed}
                  onChange={handleInputChange}
                ></input>
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

export default EditEmployeeModal;
