Feature: Related Products

Scenario Outline: Validate related product rules
    Given user opens wallet search page
    When related products are visible
    Then validate testcase <tc>

Examples:
| tc |
| 1  |
| 3  |
| 4  |
| 5  |
| 8  |
| 15 |
| 16 |