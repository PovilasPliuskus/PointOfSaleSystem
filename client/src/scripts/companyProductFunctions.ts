import { addAuthHeader } from "./authorizationFunctions";
import {
  CompanyProductObject,
  UpdateCompanyProductRequest,
} from "./interfaces";

export const fetchAllCompanyProducts = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/companyProduct", {
      method: "GET",
      credentials: "include",
      headers: {
        ...addAuthHeader(),
      },
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log(
      "Retrieved response calling fetchAllCompanyProducts: ",
      response
    );

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllCompanyProducts: ", error);
    throw error;
  }
};

export const fetchCompanyProduct = async (
  companyProductId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/companyProduct/${companyProductId}`,
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

    console.log("Retrieved response calling fetchCompanyProduct: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteCompanyProduct = async (
  companyProductId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/companyProduct/${companyProductId}`,
      {
        method: "DELETE",
        credentials: "include",
        headers: {
          ...addAuthHeader(),
        },
      }
    );

    if (!response.ok) {
      console.error(`Error deleting companyProduct: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting companyProduct:", error);
    return { success: false };
  }
};

export const UpdateCompanyProduct = async (
  updateCompanyProductRequest: UpdateCompanyProductRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/companyProduct/${updateCompanyProductRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
          ...addAuthHeader(),
        },
        body: JSON.stringify(updateCompanyProductRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing companyProduct: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("CompanyProduct updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing companyProduct", error);
    return { success: false };
  }
};

export const AddCompanyProduct = async (
  newCompanyProduct: CompanyProductObject
): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/companyProduct`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
        ...addAuthHeader(),
      },
      body: JSON.stringify(newCompanyProduct),
    });

    if (!response.ok) {
      console.error(`Error adding companyProduct: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("companyProduct added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding companyProduct", error);
    return { success: false };
  }
};
