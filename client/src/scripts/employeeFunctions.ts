import { CreateEmployeeRequest, UpdateEmployeeRequest } from "./interfaces";

export const fetchAllEmployees = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/employee", {
      method: "GET",
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchAllEmployees: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllEmployees: ", error);
    throw error;
  }
};

export const fetchEmployee = async (employeeId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/employee/${employeeId}`,
      {
        method: "GET",
        credentials: "include",
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchEmployee: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteEmployee = async (employeeId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/employee/${employeeId}`,
      {
        method: "DELETE",
        credentials: "include",
      }
    );

    if (!response.ok) {
      console.error(`Error deleting employee: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deletingemployee:", error);
    return { success: false };
  }
};

export const UpdateEmployee = async (
  updateEmployeeRequest: UpdateEmployeeRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/employee/${updateEmployeeRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updateEmployeeRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing employee: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Employeeupdated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing employee", error);
    return { success: false };
  }
};

export const AddEmployee = async (
  newEmployee: CreateEmployeeRequest
): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/employee`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newEmployee),
    });

    if (!response.ok) {
      console.error(`Error adding employee: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Employee added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding employee", error);
    return { success: false };
  }
};
