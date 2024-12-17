import { getEmployeeStatusDisplay } from "../../scripts/enums/EmployeeStatus";
import { EmployeeObject } from "../../scripts/interfaces";

interface EmployeeExpandedRowDetailsProps {
  selectedEmployee: EmployeeObject;
  onEdit: (employeeId: string) => void;
  onDelete: (employeeId: string) => void;
}

const EmployeeExpandedRowDetails: React.FC<EmployeeExpandedRowDetailsProps> = ({
  selectedEmployee,
  onEdit,
  onDelete,
}) => {
  return (
    <tr>
      <td colSpan={2}>
        <div className="border p-2">
          <p>
            <strong>Employee Name:</strong> {selectedEmployee.name}
          </p>
          <p>
            <strong>Employee Surname:</strong> {selectedEmployee.surname}
          </p>
          <p>
            <strong>Receive Time:</strong>{" "}
            {new Date(selectedEmployee.receiveTime).toLocaleString()}
          </p>
          <p>
            <strong>Update Time:</strong>{" "}
            {new Date(selectedEmployee.updateTime).toLocaleString()}
          </p>
          <p>
            <strong>Created By Employee ID: </strong>{" "}
            {selectedEmployee.createdByEmployeeId}
          </p>
          <p>
            <strong>Modified By Employee ID:</strong>{" "}
            {selectedEmployee.modifiedByEmployeeId}
          </p>
          <p>
            <strong>Status:</strong>{" "}
            {getEmployeeStatusDisplay(selectedEmployee.status)}
          </p>
          <div className="mt-2">
            <button
              className="btn btn-warning me-2"
              onClick={() => onEdit(selectedEmployee.id)}
            >
              Edit
            </button>
            <button
              className="btn btn-danger"
              onClick={() => onDelete(selectedEmployee.id)}
            >
              Delete
            </button>
          </div>
        </div>
      </td>
    </tr>
  );
};

export default EmployeeExpandedRowDetails;
