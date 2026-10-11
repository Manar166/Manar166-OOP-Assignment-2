```text
1. WardBoard

Identified Responsibilities:

Tracking bed assignments, discharge status, and physical bed inventory

Calculating patient acuity scores and evaluating isolation placement protocols.

Generating formatted clinical handover summaries for nursing staff.

Exporting HL7 ADT-style telemetry strings for hospital electronic health record (EHR) integration.

Why Coupling Is Problematic:

Combining clinical placement rules with external output formats means updating an HL7 export schema or modifying handover prose could inadvertently break bed availability tracking or acuity scoring logic. Clinical rules change via medical governance, while messaging schemas change via IT/EHR integration demands.

2. CheckoutBasket
Identified Responsibilities:

Managing shopping basket item state, quantities, and line item validation.

Calculating sub totals, applying promotional discount codes, and computing tax.

Packaging and serializing payment gateway request payloads (e.g., Stripe/PayPal JSON/XML schemas).

Rendering receipt text/markdown summaries for order confirmation emails.

Why Coupling Is Problematic:
Marketing adjustments (e.g., promo codes or discount limits) or tax rate updates shouldn't require re-testing payment gateway payload generation or email receipt templates. Tying payment gateway schema definitions directly to cart state creates a risk of exposing or corrupting transactional financial logic during UI/template updates.

3. SupportTicket
Identified Responsibilities:

Managing ticket lifecycle state (status updates, assignment, priority escalation).

Calculating SLA breach timers, resolution deadlines, and business hour escalation math.

Constructing customer notification emails and auto-reply body copy.

Formatting metric/kpi logs for analytics reporting (e.g., agent response time metrics).

Why Coupling Is Problematic:
Changes to customer-facing communication wording or internal KPI metrics shouldn't risk corrupting critical SLA timers or state transitions. Mixing support workflows with logging and messaging logic forces frequent modifications to the core domain model whenever reporting formats evolve.

4. LoanDesk
Identified Responsibilities:

Evaluating borrower risk scores and credit eligibility math.

Enforcing regulatory and compliance document requirements based on applicant profile.

Generating pre-approval and rejection decision letter prose for applicants.

Producing CSV export rows for underwriting dashboards and analytics pipelines.

Why Coupling Is Problematic:
Risk committee algorithm updates, regulatory compliance checklist changes, customer letter copy adjustments, and analytics schema shifts represent four independent drivers of change. Keeping them together makes unit testing pure financial math difficult without dragging along document and formatting dependencies.

5. CourseEnrollmentDesk
Identified Responsibilities:

Managing seat allocation, waitlist position indexing, and automatic promotions.

Formatting Markdown welcome packets and Discord onboarding instructions for students.

Calculating tuition charges, applying VAT, and generating billing invoice line items.

Validating student registration prerequisites and email duplicates.

Why Coupling Is Problematic:
Changes in academy marketing copy or finance/VAT calculation rules shouldn't affect atomic seat management and waitlist queue mechanics. Mixing monetary calculations and marketing communications into state management increases the risk of race conditions or state corruption during unrelated format updates.

6. KitchenTicket
Identified Responsibilities:

Managing kitchen ticket item states (e.g., fire, pending, completed) and course sequencing.

Estimating preparation times based on kitchen workload and dish complexity.

Generating thermal kitchen printer receipt layouts (ESC/POS formatting commands).

Calculating order total prices, prep surcharges, and table billing totals.

Why Coupling Is Problematic:
Physical hardware layout changes (such as thermal printer formatting or line wraps) should never touch cooking sequence timing or billing calculations. Placing hardware rendering in the same class as kitchen queue state makes automated testing cumbersome and fragile.

7. SubscriptionBilling
Identified Responsibilities:

Tracking subscription tiers, renewal dates, and status transitions (e.g., Active, Grace, Cancelled).

Calculating prorated upgrades/downgrades and multi-currency billing totals with tax.

Generating dunning email content and payment failure notices.

Formulating financial ledger entry audit records for accounting integration.

Why Coupling Is Problematic:
Proration rules are governed by financial policies, dunning templates by customer retention teams, and ledger records by accounting standards. Entangling state machine logic with messaging and accounting rules makes adding new billing plans or changing currency rules risky and error-prone.

8. WarehousePickList
Identified Responsibilities:

Tracking item inventory counts, bin locations, and picking completion status.

Calculating optimal warehouse aisle navigation paths and pick routing sequences.

Formatting warehouse handheld scanner display lines / barcode string layouts.

Auditing inventory variances and flagging stock adjustment logs.

Why Coupling Is Problematic:
Optimizing physical routing algorithms or updating hardware display formats should be entirely independent of inventory stock adjustments. Putting display UI strings and route optimization into the core pick-list aggregate causes frequent code churn for non-domain changes.

9. GradeBook
Identified Responsibilities:

Storing student assignment scores and calculating weighted GPA/letter grade averages.

Applying academic standing policies (e.g., honor roll, academic probation warnings).

Formulating parent/student progress report card text templates.

Exporting school registry format strings for central database synchronization.

Why Coupling Is Problematic:
Academic grading curves, report card prose formatting, and external registry data schemas change for completely different reasons. Combining them makes it easy to accidentally introduce bugs into GPA calculation logic while editing report card templates or export schemas.

10. AppointmentDesk
Identified Responsibilities:

Scheduling appointment slots, managing calendar availability, and checking conflicts.

Applying cancellation/rescheduling penalty fees and refund policies.

Generating SMS and email appointment reminders with calendar invite links (.ics).

Formatting daily practitioner schedule logs and clinical appointment rosters.

Why Coupling Is Problematic:
SMS template changes, calendar payload generation, financial cancellation penalties, and calendar slot booking logic represent distinct functional areas. Mixing calendar logic with notification rendering and financial penalties makes scheduling logic difficult to isolate, unit test, and maintain.
```