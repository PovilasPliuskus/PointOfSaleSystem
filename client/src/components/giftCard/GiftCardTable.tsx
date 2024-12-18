import React from "react";
import { GiftCardObject } from "../../scripts/interfaces";
import GiftCardExpendedRowDetails from "./GiftCardExpandedRowDetails";

interface GiftCardTableProps {
  giftCards: GiftCardObject[];
  paginatedGiftCards: GiftCardObject[];
  currentPage: number;
  pageSize: number;
  expandedRow: number | null;
  selectedGiftCard: GiftCardObject | null;

  handleRowClick: (index: number, giftCardId: string) => void;
  handleEditClick: (giftCardId: string) => void;
  handleDeleteClick: (giftCardId: string) => void;
}

const GiftCardTable: React.FC<GiftCardTableProps> = ({
  giftCards,
  paginatedGiftCards,
  currentPage,
  pageSize,
  expandedRow,
  selectedGiftCard,

  handleRowClick,
  handleEditClick,
  handleDeleteClick,
}) => {
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col">GiftCard Name</th>
        </tr>
      </thead>
      <tbody>
        {paginatedGiftCards.map((giftCard, index) => {
          const globalIndex = (currentPage - 1) * pageSize + index;
          return (
            <React.Fragment key={giftCard.id}>
              <tr
                onClick={() => handleRowClick(globalIndex, giftCard.id)}
                style={{ cursor: "pointer" }}
              >
                <th scope="row">{globalIndex + 1}</th>
                <td>{giftCard.name}</td>
              </tr>

              {expandedRow === globalIndex && selectedGiftCard && (
                <GiftCardExpendedRowDetails
                  selectedGiftCard={selectedGiftCard}
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

export default GiftCardTable;
