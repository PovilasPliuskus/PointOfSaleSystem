import { CreateOrderRequest, UpdateOrderRequest } from "./interfaces";

export const fetchAllOrders = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/order", {
      method: "GET",
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchAllOrders: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error in fetchAllOrders: ", error);
    throw error;
  }
};

export const fetchOrder = async (orderId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/order/${orderId}`,
      {
        method: "GET",
        credentials: "include",
      }
    );

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    console.log("Retrieved response calling fetchOrder: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteOrder = async (orderId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/order/${orderId}`,
      {
        method: "DELETE",
        credentials: "include",
      }
    );

    if (!response.ok) {
      console.error(`Error deleting order: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting order:", error);
    return { success: false };
  }
};

export const UpdateOrder = async (
  updateOrderRequest: UpdateOrderRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/order/${updateOrderRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(updateOrderRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing order: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Order updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing order", error);
    return { success: false };
  }
};

export const AddOrder = async (newOrder: CreateOrderRequest): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/order`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newOrder),
    });

    if (!response.ok) {
      console.error(`Error adding order: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("Order added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding order", error);
    return { success: false };
  }
};
