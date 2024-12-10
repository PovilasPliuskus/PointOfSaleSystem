import React, { useState, useEffect } from "react";
import Pagination from "./Pagination";
import "bootstrap/dist/css/bootstrap.min.css";
import { v4 as uuidv4 } from "uuid";

interface Order {
  id: string;
  name: string;
  establishmentProductId: string | null;
  establishmentServiceId: string | null;
  count: number;
  receiveTime: string;
  updateTime: string;
  createdByEmployeeId: string;
  modifiedByEmployeeId: string;
}

function Orders() {
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize, setPageSize] = useState(5);
  const [orders, setOrders] = useState<Order[]>([]);
  const [loading, setLoading] = useState(true);
  const [expandedRow, setExpandedRow] = useState<number | null>(null);
  const [selectedOrderDetails, setSelectedOrderDetails] =
    useState<Order | null>(null);

  const [showModal, setShowModal] = useState(false);
  const [newOrderName, setNewOrderName] = useState("");
  const [newOrderCount, setNewOrderCount] = useState(0);
  const [isProduct, setIsProduct] = useState(true); // Default to product
  const [productOrServiceId, setProductOrServiceId] = useState("");

  const totalItems = orders.length;
  const totalPages = Math.ceil(totalItems / pageSize);

  // Fetch initial orders list on page load
  useEffect(() => {
    const fetchOrders = async () => {
      try {
        setLoading(true);
        const response = await fetch("https://localhost:44309/api/order", {
          method: "GET",
          credentials: "include",
        });
        const data = await response.json();
        setOrders(data);
      } catch (error) {
        console.error("Error fetching orders:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchOrders();
  }, []);

  const toggleModal = () => {
    setShowModal(!showModal);

    setNewOrderName("");
    setNewOrderCount(0);
    setIsProduct(true); // Reset to product by default
    setProductOrServiceId("");
  };

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;

    if (name === "name") setNewOrderName(value);
    if (name === "count") setNewOrderCount(Number(value));
  };

  // Handle row clicks to show detailed information
  const handleRowClick = async (index: number, orderId: string) => {
    setExpandedRow(expandedRow === index ? null : index);

    if (expandedRow !== index) {
      try {
        const response = await fetch(
          `https://localhost:44309/api/order/${orderId}`,
          {
            method: "GET",
            credentials: "include",
          }
        );

        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }

        const orderDetails = await response.json();
        console.log("Fetched order details:", orderDetails);
        setSelectedOrderDetails(orderDetails);
      } catch (error) {
        console.error("Error fetching order details:", error);
      }
    }
  };

  const handleSave = async () => {
    if (selectedOrderDetails) {
      // Update existing order
      const updatedOrder = {
        ...selectedOrderDetails, // Spread existing details
        name: newOrderName,
        count: newOrderCount,
      };

      try {
        const response = await fetch(
          `https://localhost:44309/api/order/${selectedOrderDetails.id}`,
          {
            method: "PUT",
            headers: {
              "Content-Type": "application/json",
            },
            body: JSON.stringify(updatedOrder),
          }
        );

        if (!response.ok) {
          throw new Error("Failed to update order");
        }

        alert("Order updated successfully!");
        setShowModal(false);

        // Update order list after successful update
        const updatedResponse = await fetch(
          "https://localhost:44309/api/order",
          {
            method: "GET",
            credentials: "include",
          }
        );
        const updatedOrders = await updatedResponse.json();
        setOrders(updatedOrders);

        // Clear selected details if updated order is still active
        setSelectedOrderDetails(null);
      } catch (error) {
        console.error("Error updating order:", error);
      }
    } else {
      // Add new order
      const newOrder = {
        id: uuidv4(), // Generate a UUID
        name: newOrderName,
        count: newOrderCount,
        receiveTime: new Date().toISOString(),
        updateTime: new Date().toISOString(),
        createdByEmployeeId: "00000000-0000-0000-0000-000000000000",
        modifiedByEmployeeId: "00000000-0000-0000-0000-000000000000",
        establishmentProductId: isProduct ? productOrServiceId : null,
        establishmentServiceId: !isProduct ? productOrServiceId : null,
      };

      try {
        const response = await fetch("https://localhost:44309/api/order", {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(newOrder),
        });

        if (!response.ok) {
          throw new Error("Failed to save order");
        }

        alert("Order added successfully");
        setShowModal(false);

        // Refresh the order list after adding a new order
        const updatedResponse = await fetch(
          "https://localhost:44309/api/order",
          {
            method: "GET",
            credentials: "include",
          }
        );
        const updatedOrders = await updatedResponse.json();
        setOrders(updatedOrders);
      } catch (error) {
        console.error("Error saving order:", error);
        alert("Failed to add order");
      }
    }
  };

  const handleEdit = async () => {
    if (selectedOrderDetails) {
      // Pre-populate edit form with order details
      setNewOrderName(selectedOrderDetails.name);
      setNewOrderCount(selectedOrderDetails.count);

      // Open edit modal
      setShowModal(true);
    }
  };

  const handleDelete = async () => {
    if (selectedOrderDetails) {
      const confirmDelete = window.confirm(
        `Are you sure you want to delete ${selectedOrderDetails.name}?`
      );

      if (confirmDelete) {
        try {
          const response = await fetch(
            `https://localhost:44309/api/order/${selectedOrderDetails.id}`,
            {
              method: "DELETE",
              credentials: "include",
            }
          );

          if (!response.ok) {
            throw new Error("Failed to delete the order.");
          }

          alert("Order deleted successfully.");

          // Refresh the order list after successful deletion
          const updatedResponse = await fetch(
            "https://localhost:44309/api/order",
            {
              method: "GET",
              credentials: "include",
            }
          );
          const updatedOrders = await updatedResponse.json();
          setOrders(updatedOrders);

          // Clear the selected order details
          setSelectedOrderDetails(null);
        } catch (error) {
          console.error("Error deleting order:", error);
          alert("Failed to delete order.");
        }
      }
    }
  };

  const paginatedOrders = orders.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  return (
    <>
      <h1 className="text-center mb-4">Orders</h1>
      <div className="container mt-4">
        {loading ? (
          <div className="text-center">Loading...</div>
        ) : (
          <table className="table table-striped">
            <thead>
              <tr>
                <th scope="col">#</th>
                <th scope="col">Order Name</th>
                <th scope="col">Establishment Product ID</th>
                <th scope="col">Establishment Service ID</th>
              </tr>
            </thead>
            <tbody>
              {paginatedOrders.map((order, index) => {
                const globalIndex = (currentPage - 1) * pageSize + index;
                return (
                  <React.Fragment key={order.id}>
                    <tr
                      onClick={() => handleRowClick(globalIndex, order.id)}
                      style={{ cursor: "pointer" }}
                    >
                      <th scope="row">{globalIndex + 1}</th>
                      <td>{order.name}</td>
                      <td>{order.establishmentProductId}</td>
                      <td>{order.establishmentServiceId}</td>
                    </tr>

                    {expandedRow === globalIndex && selectedOrderDetails && (
                      <tr>
                        <td colSpan={4}>
                          <div className="border p-2">
                            <p>
                              <strong>Order Name:</strong>{" "}
                              {selectedOrderDetails.name}
                            </p>
                            <p>
                              <strong>Count:</strong>{" "}
                              {selectedOrderDetails.count}
                            </p>
                            <p>
                              <strong>Receive Time:</strong>{" "}
                              {new Date(
                                selectedOrderDetails.receiveTime
                              ).toLocaleString()}
                            </p>
                            <p>
                              <strong>Update Time:</strong>{" "}
                              {new Date(
                                selectedOrderDetails.updateTime
                              ).toLocaleString()}
                            </p>
                            <p>
                              <strong>Created By Employee ID:</strong>{" "}
                              {selectedOrderDetails.createdByEmployeeId}
                            </p>
                            <p>
                              <strong>Modified By Employee ID:</strong>{" "}
                              {selectedOrderDetails.modifiedByEmployeeId}
                            </p>
                            <p>
                              <strong>Establishment Product ID:</strong>{" "}
                              {selectedOrderDetails.establishmentProductId}
                            </p>
                            <p>
                              <strong>Establishment Service ID:</strong>{" "}
                              {selectedOrderDetails.establishmentServiceId}
                            </p>
                            <div className="mt-2">
                              <button
                                className="btn btn-warning me-2"
                                onClick={handleEdit}
                              >
                                Edit
                              </button>
                              <button
                                className="btn btn-danger"
                                onClick={handleDelete}
                              >
                                Delete
                              </button>
                            </div>
                          </div>
                        </td>
                      </tr>
                    )}
                  </React.Fragment>
                );
              })}
            </tbody>
          </table>
        )}
        <Pagination
          currentPage={currentPage}
          totalPages={totalPages}
          totalItems={totalItems}
          pageSize={pageSize}
          onPageChange={setCurrentPage}
          onPageSizeChange={setPageSize}
        />
        <div className="d-flex justify-content-end mt-3">
          <button className="btn btn-success btn-lg" onClick={toggleModal}>
            Add Order
          </button>
        </div>
      </div>
      {showModal && (
        <div className="modal fade show" style={{ display: "block" }}>
          <div className="modal-dialog">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">
                  {selectedOrderDetails ? "Edit Order" : "Add New Order"}
                </h5>
                <button
                  type="button"
                  className="btn-close"
                  onClick={toggleModal}
                ></button>
              </div>
              <div className="modal-body">
                <form>
                  <div className="mb-3">
                    <label className="form-label">Order Name</label>
                    <input
                      type="text"
                      className="form-control"
                      name="name"
                      value={newOrderName}
                      onChange={handleInputChange}
                    />
                  </div>
                  <div className="mb-3">
                    <label className="form-label">Count</label>
                    <input
                      type="number"
                      className="form-control"
                      name="count"
                      value={newOrderCount}
                      onChange={handleInputChange}
                    />
                  </div>
                  <div className="form-group">
                    <label>Product or Service</label>
                    <div className="form-check">
                      <input
                        type="radio"
                        className="form-check-input"
                        name="productOrService"
                        value="product"
                        checked={isProduct}
                        onChange={() => setIsProduct(true)}
                      />
                      <label className="form-check-label">Product</label>
                    </div>
                    <div className="form-check">
                      <input
                        type="radio"
                        className="form-check-input"
                        name="productOrService"
                        value="service"
                        checked={!isProduct}
                        onChange={() => setIsProduct(false)}
                      />
                      <label className="form-check-label">Service</label>
                    </div>
                  </div>
                  <div className="mb-3">
                    <label className="form-label">
                      {isProduct
                        ? "Establishment Product ID"
                        : "Establishment Service ID"}
                    </label>
                    <input
                      type="text"
                      className="form-control"
                      value={productOrServiceId}
                      onChange={(e) => setProductOrServiceId(e.target.value)}
                    />
                  </div>
                </form>
              </div>
              <div className="modal-footer">
                <button
                  type="button"
                  className="btn btn-secondary"
                  onClick={toggleModal}
                >
                  Close
                </button>
                <button
                  type="button"
                  className="btn btn-primary"
                  onClick={handleSave}
                >
                  Save Changes
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </>
  );
}

export default Orders;
