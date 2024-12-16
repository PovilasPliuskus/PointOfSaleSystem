import {
  EstablishmentServiceObject,
  UpdateEstablishmentServiceRequest,
} from "./interfaces";

export const fetchAllEstablishmentServices = async (): Promise<any> => {
  try {
    const response = await fetch(
      "https://localhost:44309/api/establishmentService",
      {
        method: "GET",
        credentials: "include",
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log(
      "Retrieved response calling fetchAllEstablishmentServices: ",
      response
    );

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllEstablishmentServices: ", error);
    throw error;
  }
};

export const fetchEstablishmentService = async (
  establishmentServiceId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishmentService/${establishmentServiceId}`,
      {
        method: "GET",
        credentials: "include",
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log(
      "Retrieved response calling fetchEstablishmentService: ",
      response
    );

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteEstablishmentService = async (
  establishmentServiceId: string
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishmentService/${establishmentServiceId}`,
      {
        method: "DELETE",
        credentials: "include",
      }
    );

    if (!response.ok) {
      console.error(
        `Error deleting establishmentService: ${response.statusText}`
      );
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting establishmentService:", error);
    return { success: false };
  }
};

export const UpdateEstablishmentService = async (
  updateEstablishmentServiceRequest: UpdateEstablishmentServiceRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishmentService/${updateEstablishmentServiceRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updateEstablishmentServiceRequest),
      }
    );

    if (!response.ok) {
      console.error(
        `Error updateing establishmentService: ${response.statusText}`
      );
      return { success: false };
    }

    const responseData = await response.json();
    console.log("EstablishmentService updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing establishmentService", error);
    return { success: false };
  }
};

export const AddEstablishmentService = async (
  newEstablishmentService: EstablishmentServiceObject
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/establishmentService`,
      {
        method: "POST",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(newEstablishmentService),
      }
    );

    if (!response.ok) {
      console.error(
        `Error adding establishmentService: ${response.statusText}`
      );
      return { success: false };
    }

    const responseData = await response.json();
    console.log("establishmentService added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding establishmentService", error);
    return { success: false };
  }
};
