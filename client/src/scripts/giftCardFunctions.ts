import Cookies from "js-cookie";
import { GiftCardObject, UpdateGiftCardRequest } from "./interfaces";
import { addAuthHeader } from "./authorizationFunctions";

export const fetchAllGiftCards = async (): Promise<any> => {
  try {
    const response = await fetch("https://localhost:44309/api/giftCard", {
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

export const fetchGiftCard = async (giftCardId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/giftCard/${giftCardId}`,
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

    console.log("Retrieved response calling fetchgiftCard: ", response);

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const DeleteGiftCard = async (giftCardId: string): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/giftCard/${giftCardId}`,
      {
        method: "DELETE",
        credentials: "include",
        headers: {
          ...addAuthHeader(),
        },
      }
    );

    if (!response.ok) {
      console.error(`Error deleting giftCard: ${response.statusText}`);
      return { success: false };
    }

    await response.json();
  } catch (error) {
    console.error("Error deleting giftCard:", error);
    return { success: false };
  }
};

export const UpdateGiftCard = async (
  updateGiftCardRequest: UpdateGiftCardRequest
): Promise<any> => {
  try {
    const response = await fetch(
      `https://localhost:44309/api/giftCard/${updateGiftCardRequest.id}`,
      {
        method: "PUT",
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
          ...addAuthHeader(),
        },
        body: JSON.stringify(updateGiftCardRequest),
      }
    );

    if (!response.ok) {
      console.error(`Error updateing giftCard: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("giftCard updated successfully: ", responseData);
  } catch (error) {
    console.error("Error updateing giftCard", error);
    return { success: false };
  }
};

export const AddGiftCard = async (newGiftCard: GiftCardObject): Promise<any> => {
  try {
    const response = await fetch(`https://localhost:44309/api/giftCard`, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
        ...addAuthHeader(),
      },
      body: JSON.stringify(newGiftCard),
    });

    if (!response.ok) {
      console.error(`Error adding giftCard: ${response.statusText}`);
      return { success: false };
    }

    const responseData = await response.json();
    console.log("giftCard added successfully: ", responseData);
  } catch (error) {
    console.error("Error adding giftCard", error);
    return { success: false };
  }
};
