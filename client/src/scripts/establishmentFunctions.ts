import {
  CreateEstablishmentRequest,
  UpdateEstablishmentRequest,
} from "./interfaces";

export const fetchAllEstablishments = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/establishment", {
      method: "GET",
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log(
      "Retrieved response calling fetchAllEstablishments: ",
      response
    );

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllEstablishments: ", error);
    throw error;
  }
};

export const fetchEstablishment = async (
  establishmentId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishment/${establishmentId}`,
      {
        method: "GET",
        credentials: "include",
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchEstablishment: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteEstablishment = async (
  establishmentId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishment/${establishmentId}`,
      {
        method: "DELETE",
        credentials: "include",
      }
    );

    if (!response.ok) {
      console.error(`Error deleting establishment: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting establishment:", error);
    return { success: false };
  }
};

export const UpdateEstablishment = async (
  updateEstablishmentRequest: UpdateEstablishmentRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishment/${updateEstablishmentRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updateEstablishmentRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing establishment: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Establishment updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing establishment", error);
    return { success: false };
  }
};

export const AddEstablishment = async (
  newEstablishment: CreateEstablishmentRequest
): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/establishment`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newEstablishment),
    });

    if (!response.ok) {
      console.error(`Error adding establishment: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Establishment added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding establishment", error);
    return { success: false };
  }
};
