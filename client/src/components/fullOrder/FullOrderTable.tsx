import React from "react";
import { FullOrderObject } from "../../scripts/interfaces";
import FullOrderExpandedRowDetails from "./FullOrderExpandedRowDetails";

interface FullOrderTableProps {
  fullOrders: FullOrderObject[];
  paginatedFullOrders: FullOrderObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedFullOrder: FullOrderObject | null;

  handleRowClick: (index: number, fullOrderId: string) => void;
  handleEditClick: (fullOrderId: string) => void;
  handleDeleteClick: (fullOrderId: string) => void;
}

const FullOrderTable: React.FC<FullOrderTableProps> = ({
  fullOrders,
  paginatedFullOrders,
  currentPage,
  pageSize,
  expandedRow,
  selectedFullOrder,

  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">Full Order Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedFullOrders.map((company, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={company.id}>
              <tr
                onClick={() => handleRowClick(globalIndex, company.id)}
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{company.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedFullOrder && (
                <FullOrderExpandedRowDetails
                  selectedFullOrder={selectedFullOrder}
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

export default FullOrderTable;
