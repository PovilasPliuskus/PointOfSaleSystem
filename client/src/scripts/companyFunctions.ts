import Cookies from "js-cookie";
import { CompanyObject, UpdateCompanyRequest } from "./interfaces";
import { addAuthHeader } from "./authorizationFunctions";

export const fetchAllCompanies = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/company", {
      method: "GET",
      credentials: "include",
      headers: {
        ...addAuthHeader(),
      },
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchAllCompanies: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllCompanies: ", error);
    throw error;
  }
};

export const fetchCompany = async (companyId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/company/${companyId}`,
      {
        method: "GET",
        credentials: "include",
        headers: {
          ...addAuthHeader(),
        },
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchCompany: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteCompany = async (companyId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/company/${companyId}`,
      {
        method: "DELETE",
        credentials: "include",
        headers: {
          ...addAuthHeader(),
        },
      }
    );

    if (!response.ok) {
      console.error(`Error deleting company: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting company:", error);
    return { success: false };
  }
};

export const UpdateCompany = async (
  updateCompanyRequest: UpdateCompanyRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/company/${updateCompanyRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
          ...addAuthHeader(),
        },
        body: JSON.stringify(updateCompanyRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing company: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Company updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing company", error);
    return { success: false };
  }
};

export const AddCompany = async (newCompany: CompanyObject): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/company`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
        ...addAuthHeader(),
      },
      body: JSON.stringify(newCompany),
    });

    if (!response.ok) {
      console.error(`Error adding company: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Company added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding company", error);
    return { success: false };
  }
};
