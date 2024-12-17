import { EmployeeObject } from "../../scripts/interfaces";
import React from "react";
import EmployeeExpandedRowDetails from "./EmployeeExpandedRowDetails";

interface EmployeeTableProps {
  employees: EmployeeObject[];
  paginatedEmployees: EmployeeObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedEmployee: EmployeeObject | null;

  handleRowClick: (index: number, employeeId: string) => void;
  handleEditClick: (employeeId: string) => void;
  handleDeleteClick: (employeeId: string) => void;
}

const EmployeeTable: React.FC<EmployeeTableProps> = ({
  employees,
  paginatedEmployees,
  currentPage,
  pageSize,
  expandedRow,
  selectedEmployee,

  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Employee Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedEmployees.map((employee, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={employee.id}>
              <tr
                onClick={() => handleRowClick(globalIndex, employee.id)}
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{employee.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedEmployee && (
                <EmployeeExpandedRowDetails
                  selectedEmployee={selectedEmployee}
                  onEdit={handleEditClick}
                  onDelete={handleDeleteClick}
                />
              )}
            </React.Fragment>
          );
        })}
      </tbody>
    </table>
  );
};

export default EmployeeTable;
