import { CreateFullOrderRequest, UpdateFullOrderRequest } from "./interfaces";

export const fetchAllFullOrders = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/fullOrder", {
      method: "GET",
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchAllFullOrders: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllFullOrders: ", error);
    throw error;
  }
};

export const fetchFullOrder = async (fullOrderId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/fullOrder/${fullOrderId}`,
      {
        method: "GET",
        credentials: "include",
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchFullOrder: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteFullOrder = async (fullOrderId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/fullOrder/${fullOrderId}`,
      {
        method: "DELETE",
        credentials: "include",
      }
    );

    if (!response.ok) {
      console.error(`Error deleting full order: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting full order:", error);
    return { success: false };
  }
};

export const UpdateFullOrder = async (
  updateFullOrderRequest: UpdateFullOrderRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/fullOrder/${updateFullOrderRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updateFullOrderRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing fullOrder: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Full order updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing full order", error);
    return { success: false };
  }
};

export const AddFullOrder = async (
  newFullOrder: CreateFullOrderRequest
): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/fullOrder`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newFullOrder),
    });

    if (!response.ok) {
      console.error(`Error adding fullOrder: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Full order added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding full order", error);
    return { success: false };
  }
};
