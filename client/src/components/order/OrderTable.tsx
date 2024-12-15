import React from "react";
import { OrderObject } from "../../scripts/interfaces";
import OrderExpandedRowDetails from "./OrderExpandedRowDetails";

interface OrderTableProps {
  orders: OrderObject[];
  paginatedOrders: OrderObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedOrder: OrderObject | null;

  handleRowClick: (index: number, orderId: string) => void;
  handleEditClick: (orderId: string) => void;
  handleDeleteClick: (orderId: string) => void;
}

const OrderTable: React.FC<OrderTableProps> = ({
  orders,
  paginatedOrders,
  currentPage,
  pageSize,
  expandedRow,
  selectedOrder,
  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Order Name</th>
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
              </tr>

              {expandedRow === globalIndex && selectedOrder && (
                <OrderExpandedRowDetails
                  selectedOrder={selectedOrder}
                  onEdit={handleEditClick}
                  onDelete={handleDeleteClick}
                />
              )}
            </React.Fragment>
          );
        })}
      </tbody>
    </table>
  );
};

export default OrderTable;
