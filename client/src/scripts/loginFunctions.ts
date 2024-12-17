import { fetchAllEmployees } from "./employeeFunctions";
import bcrypt from "bcryptjs";

export const validateEmployeeCredentials = async (
  username: string,
  password: string
): Promise<boolean> => {
  try {
    const employees = await fetchAllEmployees();

    if (!employees || !Array.isArray(employees)) {
      throw new Error("Invalid employee data received from the API.");
    }

    const isValid = employees.some(async (employee) => {
      return (
        employee.loginUsername === username &&
        (await bcrypt.compare(password, employee.loginPasswordHashed))
      );
    });

    return isValid;
  } catch (error) {
    console.error("Error validating credentials: ", error);
    return false;
  }
};
