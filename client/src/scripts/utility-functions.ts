import {
  CompanyDetails,
  UpdateCompanyRequest,
} from "../components/company/interfaces";

export const fetchAllData = async (url: string): Promise<any> => {
  try {
    const response = await fetch(url, {
      method: "GET",
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Error in fetchData:", error);
    throw error;
  }
};

export const fetchObjectById = async (url: string): Promise<any> => {
  try {
    const response = await fetch(url, {
      method: "GET",
      credentials: "include",
    });

    if (!response.ok) {
      throw new Error(`Error fetching data: ${response.statusText}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Error fetching data:", error);
    throw error;
  }
};

export const deleteObjectById = async (url: string): Promise<any> => {
  const response = await fetch(url, {
    method: "DELETE",
    credentials: "include",
  });

  if (!response.ok) {
    throw new Error(`Error deleting object: ${response.statusText}`);
  }
};

export const addCompany = async (
  url: string,
  newCompany: CompanyDetails
): Promise<{ success: boolean; data?: any }> => {
  try {
    const response = await fetch(url, {
      method: "POST",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(newCompany),
    });

    let responseData: any = null;

    // Check if the response has content
    if (response.status === 200 || response.status === 201) {
      try {
        responseData = await response.json();
      } catch (e) {
        console.log("No JSON response from the server.");
      }
    }

    if (!response.ok) {
      console.error(
        "Error creating new company:",
        response.status,
        responseData
      );
      return { success: false, data: responseData };
    }

    console.log("New company created successfully:", responseData);
    return { success: true, data: responseData };
  } catch (error) {
    console.error("Failed to create new company:", error);
    return { success: false };
  }
};

export const UpdateCompany = async (
  url: string,
  updateCompanyRequest: UpdateCompanyRequest
): Promise<any> => {
  try {
    const response = await fetch(url, {
      method: "PUT",
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(updateCompanyRequest),
    });

    if (!response.ok) {
      // Log an error if the response isn't successful
      console.error("Error updating company:", response.statusText);
      return { success: false, error: response.statusText };
    }

    const responseData = await response.json();
    console.log("Company updated successfully:", responseData);
    return { success: true, data: responseData };
  } catch (error) {
    console.error("Error sending PUT request:", error);
    return { success: false };
  }
};
