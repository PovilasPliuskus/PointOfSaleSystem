import { useEffect, useState } from "react";
import { v4 as uuidv4 } from "uuid";
import bcrypt from "bcryptjs";

import {
  CreateEmployeeRequest,
  EmployeeObject,
  EstablishmentObject,
  UpdateEmployeeRequest,
} from "../../scripts/interfaces";
import {
  AddEmployee,
  DeleteEmployee,
  fetchAllEmployees,
  fetchEmployee,
  UpdateEmployee,
} from "../../scripts/employeeFunctions";
import { fetchAllEstablishments } from "../../scripts/establishmentFunctions";
import EmployeeTable from "./EmployeeTable";
import Pagination from "../Pagination";
import EditEmployeeModal from "./EditEmployeeModal";
import AddEmployeeModal from "./AddEmployeeModal";
import Navbar from "../Navbar";

function Employee() {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [loading, setLoading] = useState(true);
  const [employees, setEmployees] = useState<EmployeeObject[]>([]);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedEmployee, setSelectedEmployee] =
    useState<EmployeeObject | null>(null);
  const [establishments, setEstablishments] = useState<EstablishmentObject[]>(
    []
  );

  const paginatedEmployeess = employees.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  // Used for Editing Employee
  const [showEditModal, setShowEditModal] = useState(false);
  const [newEditEmployeeName, setNewEditEmployeeName] = useState("");
  const [newEditEmployeeSurname, setNewEditEmployeeSurname] = useState("");
  const [newEditEmployeeSalary, setNewEditEmployeeSalary] = useState(0);
  const [newEditEmployeeStatus, setNewEditEmployeeStatus] = useState(0);
  const [newEditEmployeeLoginUsername, setNewEditEmployeeLoginUsername] =
    useState("");
  const [
    newEditEmployeeLoginPasswordHashed,
    setNewEditEmployeeLoginPasswordHashed,
  ] = useState("");

  // Used for Adding Employee
  const [showAddModal, setShowAddModal] = useState(false);
  const [newAddEmployeeName, setNewAddEmployeeName] = useState("");
  const [newAddEmployeeSurname, setNewAddEmployeeSurname] = useState("");
  const [newAddEmployeeSalary, setNewAddEmployeeSalary] = useState(0);
  const [newAddEmployeeStatus, setNewAddEmployeeStatus] = useState(0);
  const [newAddEmployeeLoginUsername, setNewAddEmployeeLoginUsername] =
    useState("");
  const [
    newAddEmployeeLoginPasswordHashed,
    setNewAddEmployeeLoginPasswordHashed,
  ] = useState("");
  const [newEstablishmentId, setNewEstablishmentId] = useState("");

  // Functions
  const handleRowClick = async (index: number, employeeId: string) => {
    console.log("Pressed handleRowClick");

    if (expandedRow === index) {
      setExpandedRow(null);
      return;
    }

    if (expandedRow !== index) {
      try {
        const selectedEmployee = await fetchEmployee(employeeId);

        console.log("Fetched selected employee details: ", selectedEmployee);
        setSelectedEmployee(selectedEmployee);
        setExpandedRow(index);
      } catch (error) {
        console.error("Error fetching employee details:", error);
      }
    }
  };

  const handleEditClick = () => {
    console.log("Pressed handleEditClick");

    if (selectedEmployee) {
      setShowEditModal(true);
      setNewEditEmployeeName(selectedEmployee.name);
      setNewEditEmployeeSurname(selectedEmployee.surname);
      setNewEditEmployeeSalary(selectedEmployee.salary);
      setNewEditEmployeeStatus(selectedEmployee.status);
      setNewEditEmployeeLoginUsername(selectedEmployee.loginUsername);
      setNewEditEmployeeLoginPasswordHashed(
        selectedEmployee.loginPasswordHashed
      );
    }
  };

  const toggleEditEmployeeModal = () => {
    setShowEditModal(!showEditModal);
  };

  const toggleAddEmployeeModal = () => {
    setShowAddModal(!showAddModal);
  };

  const handleEditInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (type === "select-one") {
      if (name === "employeeStatus") {
        setNewEditEmployeeStatus(Number(value));
      }
    } else if (type === "text" || type === "number" || type === "password") {
      if (name === "name") setNewEditEmployeeName(value);
      if (name === "surname") setNewEditEmployeeSurname(value);
      if (name === "salary") setNewEditEmployeeSalary(parseFloat(value));
      if (name === "loginUsername") setNewEditEmployeeLoginUsername(value);
      if (name === "loginPasswordHashed")
        setNewEditEmployeeLoginPasswordHashed(value);
    }
  };

  const handleAddInputChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value, type } = e.target;

    if (name === "establishmentId") {
      setNewEstablishmentId(value);
      console.log(`VALUE = ${newEstablishmentId}`);
    }

    if (type === "select-one") {
      if (name === "employeeStatus") {
        setNewAddEmployeeStatus(Number(value));
      }
    } else if (type === "text" || type === "number" || type === "password") {
      if (name === "name") setNewAddEmployeeName(value);
      if (name === "surname") setNewAddEmployeeSurname(value);
      if (name === "salary") setNewAddEmployeeSalary(parseFloat(value));
      if (name === "loginUsername") setNewAddEmployeeLoginUsername(value);
      if (name === "loginPasswordHashed")
        setNewAddEmployeeLoginPasswordHashed(value);
    }
  };

  const handleEditSaveEmployee = async () => {
    const hashedPassword = await bcrypt.hash(
      newEditEmployeeLoginPasswordHashed,
      0
    );
    console.log("Pressed Edit Save");
    if (selectedEmployee) {
      const updatedEmployee: UpdateEmployeeRequest = {
        id: selectedEmployee.id,
        name: newEditEmployeeName,
        surname: newEditEmployeeSurname,
        salary: newEditEmployeeSalary,
        status: newEditEmployeeStatus,
        loginUsername: newEditEmployeeLoginUsername,
        loginPasswordHashed: hashedPassword,
        updateTime: new Date().toISOString(),
      };

      const success = await UpdateEmployee(updatedEmployee);

      if (!success) {
        alert("Failed to update employee");
        return;
      }

      alert("Employee updated successfully");

      toggleEditEmployeeModal();
      setExpandedRow(null);
      loadEmployees();
    }
  };

  const handleAddSaveEmployees = async () => {
    const hashedPassword = await bcrypt.hash(
      newEditEmployeeLoginPasswordHashed,
      0
    );
    console.log("Pressed Edit Save");
    const newEmployee: CreateEmployeeRequest = {
      id: uuidv4(),
      name: newAddEmployeeName,
      updateTime: new Date().toISOString(),
      receiveTime: new Date().toISOString(),
      createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
      modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
      surname: newAddEmployeeSurname,
      salary: newAddEmployeeSalary,
      status: newAddEmployeeStatus,
      loginUsername: newAddEmployeeLoginUsername,
      loginPasswordHashed: hashedPassword,
      fkEstablishmentId: newEstablishmentId,
    };

    console.log("Add employee request body: ", newEmployee);

    const success = await AddEmployee(newEmployee);

    if (!success) {
      alert("Failed to add employee");
      return;
    }

    alert("Employee added successfully");

    toggleAddEmployeeModal();
    loadEmployees();
    setNewAddEmployeeName("");
    setNewAddEmployeeSurname("");
    setNewAddEmployeeSalary(0);
    setNewAddEmployeeStatus(0);
    setNewAddEmployeeLoginUsername("");
    setNewAddEmployeeLoginPasswordHashed("");
    setNewEstablishmentId("");
  };

  const handleDeleteClick = async () => {
    console.log("Pressed handleDeleteClick");
    if (selectedEmployee) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedEmployee.name}?`
      );

      if (confirmDelete) {
        const success = await DeleteEmployee(selectedEmployee.id);

        if (!success) {
          alert("Failed to delete employee");
          return;
        }

        alert("Employee deleted successfully");

        setExpandedRow(null);
        loadEmployees();
      }
    }
  };

  const loadEmployees = async () => {
    try {
      setLoading(true);
      const data = await fetchAllEmployees();
      console.log("Retrieved from function loadEmployees: ", data);
      setEmployees(data);
      const establishments = await fetchAllEstablishments();
      setEstablishments(establishments);
    } catch (error) {
      console.error("Error loading employees: ", error);
    } finally {
      setLoading(false);
    }
  };

  //Calls when component is fully loaded
  useEffect(() => {
    loadEmployees();
  }, []);

  return (
    <>
      <Navbar />
      <h1 className="text-center mb-4">Employees</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <EmployeeTable
            employees={employees}
            paginatedEmployees={paginatedEmployeess}
            currentPage={currentPage}
            pageSize={pageSize}
            expandedRow={expandedRow}
            selectedEmployee={selectedEmployee}
            handleRowClick={handleRowClick}
            handleEditClick={handleEditClick}
            handleDeleteClick={handleDeleteClick}
          />
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={Math.ceil(employees.length / pageSize)}
          totalItems={employees.length}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button
            className="btn btn-success btn-lg"
            onClick={toggleAddEmployeeModal}
          >
            Add Employee
          </button>
        </div>
      </div>
      <EditEmployeeModal
        showModal={showEditModal}
        toggleModal={toggleEditEmployeeModal}
        newEmployeeName={newEditEmployeeName}
        newEmployeeSurname={newEditEmployeeSurname}
        newEmployeeSalary={newEditEmployeeSalary}
        newEmployeeStatus={newEditEmployeeStatus}
        newEmployeeLoginUsername={newEditEmployeeLoginUsername}
        newEmployeeLoginPasswordHashed={newEditEmployeeLoginPasswordHashed}
        handleInputChange={handleEditInputChange}
        handleSave={handleEditSaveEmployee}
      />
      <AddEmployeeModal
        showModal={showAddModal}
        toggleModal={toggleAddEmployeeModal}
        newEmployeeName={newAddEmployeeName}
        newEmployeeSurname={newAddEmployeeSurname}
        newEmployeeSalary={newAddEmployeeSalary}
        newEmployeeStatus={newAddEmployeeStatus}
        newEmployeeLoginUsername={newAddEmployeeLoginUsername}
        newEmployeeLoginPasswordHashed={newAddEmployeeLoginPasswordHashed}
        establishments={establishments}
        handleInputChange={handleAddInputChange}
        handleSave={handleAddSaveEmployees}
      />
    </>
  );
}

export default Employee;
