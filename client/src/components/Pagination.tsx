import React from "react";

interface PaginationProps {
  currentPage: number;
  totalPages: number;
  totalItems: number;
  pageSize: number;
  onPageChange: (page: number) => void;
  onPageSizeChange: (size: number) => void;
}

const Pagination: React.FC<PaginationProps> = ({
  currentPage,
  totalPages,
  totalItems,
  pageSize,
  onPageChange,
  onPageSizeChange,
}) => {
  const handlePageClick = (page: number) => {
    if (page >= 1 && page <= totalPages) {
      onPageChange(page);
    }
  };

  const handlePageSizeChange = (
    event: React.ChangeEvent<HTMLSelectElement>
  ) => {
    onPageSizeChange(parseInt(event.target.value, 10));
    onPageChange(1); // Reset to the first page when page size changes
  };

  return (
    <div>
      <div className="d-flex justify-content-between align-items-center mb-3">
        <span>Total Items: {totalItems}</span>
        <div className="d-flex align-items-center">
          <label htmlFor="pageSizeSelect" className="me-2">
            Items Per Page:
          </label>
          <select
            id="pageSizeSelect"
            value={pageSize}
            onChange={handlePageSizeChange}
            className="form-select"
            style={{ width: "auto" }}
          >
            {[5, 10, 20, 50].map((size) => (
              <option key={size} value={size}>
                {size}
              </option>
            ))}
          </select>
        </div>
      </div>

      <nav aria-label="Page navigation">
        <ul className="pagination justify-content-center">
          <li className={`page-item ${currentPage === 1 ? "disabled" : ""}`}>
            <button
              className="page-link"
              onClick={() => handlePageClick(currentPage - 1)}
              disabled={currentPage === 1}
            >
              Prev
            </button>
          </li>
          {Array.from({ length: totalPages }, (_, i) => (
            <li
              key={i + 1}
              className={`page-item ${i + 1 === currentPage ? "active" : ""}`}
            >
              <button
                className="page-link"
                onClick={() => handlePageClick(i + 1)}
              >
                {i + 1}
              </button>
            </li>
          ))}
          <li
            className={`page-item ${
              currentPage === totalPages ? "disabled" : ""
            }`}
          >
            <button
              className="page-link"
              onClick={() => handlePageClick(currentPage + 1)}
              disabled={currentPage === totalPages}
            >
              Next
            </button>
          </li>
        </ul>
      </nav>
    </div>
  );
};

export default Pagination;
