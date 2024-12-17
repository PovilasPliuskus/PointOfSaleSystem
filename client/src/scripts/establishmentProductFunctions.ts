import { addAuthHeader } from "./authorizationFunctions";
import {
  EstablishmentProductObject,
  UpdateEstablishmentProductRequest,
} from "./interfaces";

export const fetchAllEstablishmentProducts = async (): Promise<any> => {
  try {
    const response = await fetch(
      "https://localhost:44309/api/establishmentProduct",
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

    console.log(
      "Retrieved response calling fetchAllEstablishmentProducts: ",
      response
    );

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllEstablishmentProducts: ", error);
    throw error;
  }
};

export const fetchEstablishmentProduct = async (
  establishmentProductId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishmentProduct/${establishmentProductId}`,
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

    console.log(
      "Retrieved response calling fetchEstablishmentProduct: ",
      response
    );

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteEstablishmentProduct = async (
  establishmentProductId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishmentProduct/${establishmentProductId}`,
      {
        method: "DELETE",
        credentials: "include",
        headers: {
          ...addAuthHeader(),
        },
      }
    );

    if (!response.ok) {
      console.error(
        `Error deleting establishmentProduct: ${response.statusText}`
      );
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting establishmentProduct:", error);
    return { success: false };
  }
};

export const UpdateEstablishmentProduct = async (
  updateEstablishmentProductRequest: UpdateEstablishmentProductRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishmentProduct/${updateEstablishmentProductRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
          ...addAuthHeader(),
        },
        body: JSON.stringify(updateEstablishmentProductRequest),
      }
    );

    if (!response.ok) {
      console.error(
        `Error updateing establishmentProduct: ${response.statusText}`
      );
      return { success: false };
    }

    const responseData = await response.json();
    console.log("EstablishmentProduct updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing establishmentProduct", error);
    return { success: false };
  }
};

export const AddEstablishmentProduct = async (
  newEstablishmentProduct: EstablishmentProductObject
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishmentProduct`,
      {
        method: "POST",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
          ...addAuthHeader(),
        },
        body: JSON.stringify(newEstablishmentProduct),
      }
    );

    if (!response.ok) {
      console.error(
        `Error adding establishmentProduct: ${response.statusText}`
      );
      return { success: false };
    }

    const responseData = await response.json();
    console.log("establishmentProduct added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding establishmentProduct", error);
    return { success: false };
  }
};
