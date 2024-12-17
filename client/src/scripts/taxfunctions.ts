import Cookies from "js-cookie";
import { TaxObject, UpdateTaxRequest } from "./interfaces";
import { addAuthHeader } from "./authorizationFunctions";

export const fetchAllTaxes = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/tax", {
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

export const fetchTax = async (taxId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/tax/${taxId}`,
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

    console.log("Retrieved response calling fetchtax: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteTax = async (taxId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/tax/${taxId}`,
      {
        method: "DELETE",
        credentials: "include",
        headers: {
          ...addAuthHeader(),
        },
      }
    );

    if (!response.ok) {
      console.error(`Error deleting tax: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting tax:", error);
    return { success: false };
  }
};

export const UpdateTax = async (
  updateTaxRequest: UpdateTaxRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/tax/${updateTaxRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
          ...addAuthHeader(),
        },
        body: JSON.stringify(updateTaxRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing tax: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("tax updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing tax", error);
    return { success: false };
  }
};

export const AddTax = async (newTax: TaxObject): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/tax`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
        ...addAuthHeader(),
      },
      body: JSON.stringify(newTax),
    });

    if (!response.ok) {
      console.error(`Error adding tax: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("tax added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding tax", error);
    return { success: false };
  }
};
