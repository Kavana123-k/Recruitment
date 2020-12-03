using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
namespace Recruit.Models
{
    [Migration(20201117141200)]
    public class CreateTables : Migration
    {
      

        public override void Up()
        {

           
            Create.Table("tbl_logins").WithDescription("Table to Store the Login credentials")                                   //Creation of tbl_logins
                .WithColumn("user_id").AsString(20).PrimaryKey("PK_tbl_logins_UserId").WithColumnDescription("Userid for login")
                .WithColumn("first_name").AsString(50).NotNullable().WithColumnDescription("First name of the user for login")
                .WithColumn("last_name").AsString(50).NotNullable().WithColumnDescription("Last name of the user for login")
                .WithColumn("password").AsString(16).NotNullable().WithColumnDescription("Password of specific user");

            Create.Table("tbl_employees").WithDescription("Table used to keep track of the Employee invovled")                       //Creation of tbl_employees
                 .WithColumn("id").AsString(5).PrimaryKey("PK_tbl_employees_Id").WithColumnDescription("id of the employee")
                .WithColumn("name").AsString(50).NotNullable().WithColumnDescription("Name of the Employee");

            Create.Table("tbl_sources").WithDescription("Table used to store details About applicants Source")                           //Creation of tbl_sources
                .WithColumn("code").AsString(15).PrimaryKey("PK_tbl_sources_Code").WithColumnDescription("Code for the respective Source")
               .WithColumn("name").AsString(25).NotNullable().WithColumnDescription("Name of the Source");

            Create.Table("tbl_locations").WithDescription("Table used to Store Locations")                                                //Creation of tbl_locations
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_Locations_Id").WithColumnDescription("id of the specific Location").Identity()
               .WithColumn("city").AsString(20).NotNullable().WithColumnDescription("Name of the city");

            Create.Table("tbl_process_statuses").WithDescription("Table used to Store interview Process statuses")                            //Creation of tbl_process_statuses
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_process_statuses_Id").WithColumnDescription("id of the specific ProcessStatuses").Identity()
               .WithColumn("code").AsString(15).NotNullable().Unique().WithColumnDescription("Code of the specified Process status")
                .WithColumn("status").AsString(50).NotNullable().WithColumnDescription("Status of the round of interview")
                .WithColumn("colour").AsString(10).Nullable().WithColumnDescription("Colour based on the interview status");

            Create.Table("tbl_process_stages").WithDescription("Table used to Store Interview Stages")                                       //Creation of tbl_process_stages 
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_process_stages_Id").WithColumnDescription("id of the specific ProcessStages").Identity()
               .WithColumn("code").AsString(15).Unique().NotNullable().WithColumnDescription("Code of the specified Process stages")
                .WithColumn("stage").AsString(50).NotNullable().WithColumnDescription("Stages of the round of interview");

            Create.Table("tbl_vacancies").WithDescription("Table used to store Requirements and vacancies Details")                          //Creation of tbl_vacancies
                .WithColumn("code").AsString(15).PrimaryKey("PK_tbl_vacancies_Code").WithColumnDescription("Code for specific Job positions")
               .WithColumn("name").AsString(50).NotNullable().WithColumnDescription("Name of the Position that is open for applicant/Company Requirements")
                .WithColumn("vacancy").AsInt64().Nullable().WithColumnDescription("Vacancies in the specified field");

            Create.Table("tbl_interview_round_statuses").WithDescription("Table used to store Roundwise Interview statuses")                           //Creation of tbl_interview_round_statuses
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_interview_round_statuses_Id").WithColumnDescription("id of the specific ProcessStatuses").Identity()
                .WithColumn("status").AsString(20).NotNullable().WithColumnDescription("Status of the roundwise of interview statuses");

            Create.Table("tbl_owners").WithDescription("Table used to store resume owners details")                                                  //Creation of tbl_owners
                .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_owners_Id").WithColumnDescription("id of the specific Owner").Identity()
                .WithColumn("first_name").AsString(50).NotNullable().WithColumnDescription("FirstName of the Owners")
               .WithColumn("last_name").AsString(50).NotNullable().WithColumnDescription("LastName of the Owners");

            //Creating the Main table
            Create.Table("tbl_candidates").WithDescription("Table to Store the details of the Candidate")                            //Creation of tbl_candidates
         .WithColumn("id").AsInt64().PrimaryKey("PK_tbl_candidates_Id").Identity().WithColumnDescription("Primary key suto incremented")
         .WithColumn("first_name").AsString(50).NotNullable().WithColumnDescription("FirstName of the Candidate")
         .WithColumn("last_name").AsString(50).NotNullable().WithColumnDescription("LastName of the Candidate")
         .WithColumn("email").AsString(50).NotNullable().WithColumnDescription("Email of the Candidate")
         .WithColumn("phone").AsString(15).NotNullable().WithColumnDescription("Phone No of the Candidate")
         .WithColumn("source_code").AsString(15).NotNullable().WithColumnDescription("Foreignkey references the Source table defines the source of the candidate resume")
         .ForeignKey("FK_tbl_candidates_tbl_sources_Sources", "tbl_sources", "code")
         .WithColumn("referral_id").AsString(5).Nullable().WithColumnDescription("Foreignkey references the tblEmployoee table defines the Id of the employee who refered the candidate")
         .ForeignKey("FK_tbl_candidates_tbl_employees_ReferralId", "tbl_employees", "id")
         .WithColumn("total_experience").AsInt64().NotNullable().WithColumnDescription("Total experience of the candidate")
         .WithColumn("relevant_experience").AsInt64().NotNullable().WithColumnDescription("Relevant Experience of the candidate")
         .WithColumn("current_employer").AsString(30).Nullable().WithColumnDescription("Current Employer of the Candidate")
         .WithColumn("current_designation").AsString().NotNullable().WithColumnDescription("Current Designation of the candidate")
         .WithColumn("position_applied_code").AsString(15).NotNullable().WithColumnDescription("Foreignkey references the tbl_vacancies table defines the Code of the position that is vacant")
         .ForeignKey("FK_tbl_candidates_tbl_vacancies_PositionAppliedCode", "tbl_vacancies", "code")
         .WithColumn("current_ctc").AsInt64().NotNullable().WithColumnDescription("Current ctc of the candidate")
         .WithColumn("expected_ctc").AsInt64().NotNullable().WithColumnDescription("Expected ctc of the candidate")
         .WithColumn("reason_for_change").AsString(150).Nullable().WithColumnDescription("Reason for the candidate to change")
         .WithColumn("notice_period").AsInt64().NotNullable().WithColumnDescription("Notice period if any in days/if no notice period the zero as value")
         .WithColumn("is_serving_notice").AsBoolean().NotNullable().WithColumnDescription("if the candidate is serving the notice period yes or NO as value")
         .WithColumn("last_working_day").AsDate().Nullable().WithColumnDescription("if hes serving the when will the last working day be")
         .WithColumn("current_location").AsString(30).NotNullable().WithColumnDescription("current location of the candidate")
         .WithColumn("process_stage_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_process_stages table defines the Id of the process stages")
         .ForeignKey("FK_tbl_candidates_tbl_process_stages_ProcessStageId", "tbl_process_stages", "id")
         .WithColumn("process_stage_date").AsDateTime().NotNullable().WithColumnDescription("Process Stage udpated Date")
         .WithColumn("process_start_date").AsDateTime().NotNullable().WithColumnDescription("Process Start date for the candidate used for keeping track history of the candidate for next interview")
          .WithColumn("process_end_date").AsDateTime().Nullable().WithColumnDescription("Process end date for the candidate used for keeping track of history of the candidate for next interview")
          .WithColumn("interview_status_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_process_statuses table defines the Id of the process statuses")
          .ForeignKey("FK_tbl_candidates_tbl_process_statuses_InterviewStatusId", "tbl_process_statuses", "id")
          .WithColumn("resume_owner_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_process_statuses table defines the Owner of the resume")
          .ForeignKey("FK_tbl_candidates_tbl_owners_Resume_owner_id", "tbl_owners", "id")
           .WithColumn("owner_for_reminder_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_process_statuses table defines the Owner of the resume for Reminder")
          .ForeignKey("FK_tbl_candidates_tbl_owners_OwnerForReminder", "tbl_owners", "id")
          .WithColumn("comments").AsString(150).Nullable().WithColumnDescription("Comments on the interview process")
          .WithColumn("date_of_joining").AsDate().Nullable().WithColumnDescription("date of Joining of the CAndidate")
         .WithColumn("notes").AsString(150).Nullable().WithColumnDescription("Notes about the candidate")
         .WithColumn("links_for_interview").AsString(100).Nullable().WithColumnDescription("google Meet/zoom links for interview");

            //Creation of Linked table creation

            Create.Table("tbl_preferred_locations").WithDescription("Table used to store the prefered locations as it will be multiple")                  //Creation of tbl_preferred_locations
            .WithColumn("candidate_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_candidates table defines the id of the candidate")
            .ForeignKey("FK_tbl_preferred_locations_tbl_candidates_CandidateId", "tbl_candidates", "id")
            .WithColumn("location_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_locations table defines the cities")
            .ForeignKey("FK_tbl_preferred_locations_tbl_Locations_LocationId", "tbl_locations", "id");

            Create.Table("tbl_interview_details").WithDescription("Table used to store the Interview Details")                                             //Creation of tbl_interview_details
                .WithColumn("candidate_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_candidates table defines the id of the candidate")
                 .ForeignKey("FK_tbl_interview_details_tbl_candidates_CandidateId", "tbl_candidates", "id")

                .WithColumn("start_date_time").AsDateTime().NotNullable().WithColumnDescription("Start date for the candidate used for keeping of history of the candidate interview details")
                 .WithColumn("end_date_time").AsDateTime().NotNullable().WithColumnDescription("end date for the candidate used for keeping track of history of the candidate interview details")
                 .WithColumn("status_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_interview_round_statuses table defines the the round status")
                 .ForeignKey("FK_tbl_interview_details_tblInteviewRoundStatuses_StatusId", "tbl_interview_round_statuses", "id")
                 .WithColumn("reason").AsString(150).Nullable().WithColumnDescription("Notes on the Interview Process if needed");

        }
        public override void Down()
        {
            Delete.Table("tbl_logins");
            Delete.Table("tbl_employees");
            Delete.Table("tbl_sources");
            Delete.Table("tbl_locations");
            Delete.Table("tbl_process_statuses");
            Delete.Table("tbl_process_stages");
            Delete.Table("tbl_vacancies");
            Delete.Table("tbl_interview_round_statuses");
            Delete.Table("tbl_owners");
            Delete.Table("tbl_candidates");
            Delete.Table("tbl_preferred_locations");
            Delete.Table("tbl_interview_details");


        }
    }
    /// <summary>
    /// insert default values to the tables
    /// </summary>
    [Migration(20201117142400)]
    public class InsertValues : Migration
    {
        public override void Up()
        {

            Insert.IntoTable("tbl_owners").Row(new { first_name = "Jo", last_name = "tetherfi" });
            Insert.IntoTable("tbl_owners").Row(new { first_name = "Laxman", last_name = "tetherfi" });
            Insert.IntoTable("tbl_owners").Row(new { first_name = "chelsea", last_name = "tetherfi" });
            Insert.IntoTable("tbl_locations").Row(new { city = "Mangaluru" });
            Insert.IntoTable("tbl_locations").Row(new { city = "Bengaluru" });

            Insert.IntoTable("tbl_sources").Row(new { code = "linkedin", name = "LinkedIn" });
            Insert.IntoTable("tbl_sources").Row(new { code = "naukri", name = "Naukri.com" });
            Insert.IntoTable("tbl_sources").Row(new { code = "Refer", name = "Employee Referrals" });
            Insert.IntoTable("tbl_employees").Row(new { id = "IN001", name = "Bharish" });
            Insert.IntoTable("tbl_employees").Row(new { id = "IN002", name = "Vishal" });
            Insert.IntoTable("tbl_employees").Row(new { id = "IN003", name = "Sharan" });
            Insert.IntoTable("tbl_employees").Row(new { id = "IN004", name = "Adithya" });
            Insert.IntoTable("tbl_employees").Row(new { id = "IN005", name = "Ankitha" });
            Insert.IntoTable("tbl_logins").Row(new { user_id = "admin", first_name = "Admin", last_name = "01", password = "password" });
            Insert.IntoTable("tbl_logins").Row(new { user_id = "IN001", first_name = "Jo", last_name = "tetherfi", password = "abc001" });
            Insert.IntoTable("tbl_logins").Row(new { user_id = "IN002", first_name = "Laxman", last_name = "tetherfi", password = "abc002" });
            Insert.IntoTable("tbl_logins").Row(new { user_id = "IN003", first_name = "chelsea", last_name = "tetherfi", password = "abc003" });


            Insert.IntoTable("tbl_vacancies").Row(new { code = "dot_net", name = "   Sr.Software / Software Engineer - .Net", vacancy = "1" });
            Insert.IntoTable("tbl_vacancies").Row(new { code = "frontend_ui", name = "Front - End Developers - UI", vacancy = "2" });
            Insert.IntoTable("tbl_vacancies").Row(new { code = "angular_js", name = "Angular JS developer", vacancy = "3" });
            Insert.IntoTable("tbl_vacancies").Row(new { code = "ml_fresher", name = "AI / ML - fresher", vacancy = "4" });
            Insert.IntoTable("tbl_vacancies").Row(new { code = "dev_trainee", name = "Trainee Software Developer", vacancy = "5" });

            Insert.IntoTable("tbl_process_stages").Row(new { code = "initial_stage", stage = "Initial stage" });
            Insert.IntoTable("tbl_process_stages").Row(new { code = "phn_screening", stage = "Phone Screening Done" });
            Insert.IntoTable("tbl_process_stages").Row(new { code = "apti_given", stage = "Aptitude Test Given" });
            Insert.IntoTable("tbl_process_stages").Row(new { code = "apti_rcvd", stage = "Aptitude Test Received" });
            Insert.IntoTable("tbl_process_stages").Row(new { code = "asgnmt_gvn", stage = "Assignment Given" });
            Insert.IntoTable("tbl_process_stages").Row(new { code = "asgnmt_rcvd", stage = "Assignment Received" });


            Insert.IntoTable("tbl_process_statuses").Row(new { code = "initial_stage", status = "Initial stage", colour = "#FFFFFF" });
            Insert.IntoTable("tbl_process_statuses").Row(new { code = "mt_invite_snt", status = "Meeting Invite sent", colour = "#C0C0C0" });
            Insert.IntoTable("tbl_process_statuses").Row(new { code = "mt_ivt_yet_snt", status = "offer letter sent", colour = "#808080" });
            Insert.IntoTable("tbl_process_statuses").Row(new { code = "offer_sent", status = "Meeting Invite sent", colour = "#FF0000" });
            Insert.IntoTable("tbl_process_statuses").Row(new { code = "offer_yet_send", status = "offer letter yet to send", colour = "#800000" });
            Insert.IntoTable("tbl_process_statuses").Row(new { code = "Candi_joined", status = "Candidate joined", colour = "#FFFF00" });



            Insert.IntoTable("tbl_interview_round_statuses").Row(new { status = "Cleared" });
            Insert.IntoTable("tbl_interview_round_statuses").Row(new { status = "Rejected" });
            Insert.IntoTable("tbl_interview_round_statuses").Row(new { status = "Onhold" });
            Insert.IntoTable("tbl_interview_round_statuses").Row(new { status = "Cancelled" });



        }
        public override void Down()
        {
            Delete.FromTable("tbl_owners").AllRows();
            Delete.FromTable("tbl_locations").AllRows();
            Delete.FromTable("tbl_sources").AllRows();
            Delete.FromTable("tbl_employees").AllRows();
            Delete.FromTable("tbl_logins").AllRows();
            Delete.FromTable("tbl_vacancies").AllRows();
            Delete.FromTable("tbl_process_stages").AllRows();
            Delete.FromTable("tbl_process_statuses").AllRows();
            Delete.FromTable("tbl_interview_round_statuses").AllRows();
        }
    }
    [Migration(20201118150400)]
    public class InsertiontblCandidate : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("tbl_candidates").Row(new
            {
                first_name = "harish",
                last_name = "Alva",
                email = "bsal@gl.com1111",
                phone = "8073370940930",
                source_code = "Refer",
                referral_id = "IN003",
                total_experience = 12,
                relevant_experience = 12,
                current_employer = "Fresher",
                current_designation = "Fresher",
                position_applied_code = "dev_trainee",
                current_ctc = 000000,
                expected_ctc = 1000000,
                reason_for_change = "none",
                notice_period = 0,
                is_serving_notice = false,
                last_working_day = "2020/10/11",
                current_location = "Mangaluru",
                process_stage_id = 01,
                process_stage_date = "2020/10/11",
                process_start_date = "2020/10/11",
                process_end_date = "2020/10/11",
                interview_status_id = 1,
                resume_owner_id = 01,
                owner_for_reminder_id = 01,
                comments = "none",
                date_of_joining = "2020/10/11",
                notes = "none",
                links_for_interview = "none"
            });
        }

        public override void Down()
        {

        }
    }
    [Migration(20201118170500)]
    public class Inserttblinetviewers : Migration
    {
        public override void Up()
        {
            Create.Table("tbl_interviewers").WithDescription("Table used to store the multiple ineterviewer details")                  //Creation of tbl_preferred_locations
            .WithColumn("candidate_id").AsInt64().NotNullable().WithColumnDescription("Foreignkey references the tbl_candidates table defines the id of the candidate")
        .ForeignKey("FK_tbl_interviewers_tbl_candidates_CandidateId", "tbl_candidates", "id")
        .WithColumn("employee_id").AsString(5).NotNullable().WithColumnDescription("Foreignkey references the tbl_employees table defines the interviewers")
        .ForeignKey("FK_tbl_interviewers_tbl_employees_employye_id", "tbl_employees", "id");
        }

        public override void Down()
        {
            Delete.Table("tbl_interviewers");
        }
    }
    [Migration(20201120165000)]
    public class InsertiontblCandidatethree : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("tbl_candidates").Row(new
            {
                first_name = "barsa",
                last_name = "Alva",
                email = "bsal@gl.com1111",
                phone = "8073370940930",
                source_code = "Refer",
                referral_id = "IN003",
                total_experience = 12,
                relevant_experience = 12,
                current_employer = "Fresher",
                current_designation = "Fresher",
                position_applied_code = "dev_trainee",
                current_ctc = 000000,
                expected_ctc = 1000000,
                reason_for_change = "none",
                notice_period = 0,
                is_serving_notice = false,
                last_working_day = "2020/10/11",
                current_location = "Mangaluru",
                process_stage_id = 01,
                process_stage_date = "2020/10/11",
                process_start_date = "2020/10/11",
                process_end_date = "2020/10/11",
                interview_status_id = 1,
                resume_owner_id = 01,
                owner_for_reminder_id = 01,
                comments = "none",
                date_of_joining = "2020/10/11",
                notes = "none",
                links_for_interview = "none"
            });
        }

        public override void Down()
        {

        }
    }
    [Migration(20201202105000)]
    public class InsertStoredProcedure : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"CREATE proc sp_candidates_add    @first_name	nvarchar(50), @last_name	nvarchar(50), @email	nvarchar(50),
                            @phone	nvarchar(15),@source_code	nvarchar(15),  @referral_id	nvarchar(5)=' '	, @total_experience	bigint	,
                        @relevant_experience	bigint,	 @current_employer	nvarchar(30)=' ',   @current_designation	nvarchar(25),
                        @position_applied_code	nvarchar(15),@current_ctc	bigint	,@expected_ctc	bigint	,@reason_for_change	nvarchar(150)=' ',
                        @notice_period	bigint	,@is_serving_notice	bit	,@last_working_day	date=NULL,@current_location	nvarchar(30),@process_stage_id	bigint	,@process_stage_date	datetime,	
                        @process_start_date	datetime,@process_end_date	datetime=NULL ,@interview_status_id	bigint	,@resume_owner_id	bigint	,@owner_for_reminder_id	bigint,@comments	nvarchar(150)=' ',
                        @date_of_joining	date= NULL,@notes	nvarchar(150)=' ',@links_for_interview	nvarchar(100)=' '

                               as
                                 begin
                                 insert into tbl_candidates values (
    
                    @first_name	,@last_name	,@email	,@phone	,@source_code	,@referral_id		,@total_experience,@relevant_experience,@current_employer,@current_designation	,@position_applied_code,
                    @current_ctc		,@expected_ctc		,@reason_for_change	,@notice_period		,@is_serving_notice	,@last_working_day	,@current_location	,@process_stage_id	,@process_stage_date	,	
                    @process_start_date	,@process_end_date	,@interview_status_id		,@resume_owner_id	,@owner_for_reminder_id	,@comments	,@date_of_joining	,@notes	,@links_for_interview)end");
            
            Execute.Sql(@"CREATE proc sp_interview_details_add
                        @candidate_id	bigint,
                        @start_date_time datetime,@end_date_time datetime,@status_id  bigint,@reason nvarchar(150)='None'

                                 as
                                    begin
                                          insert into tbl_interview_details values (@candidate_id,@start_date_time ,@end_date_time ,@status_id ,@reason)     end");
            Execute.Sql(@"CREATE proc sp_locations_add @city nvarchar(20)     as
                           begin
                 insert into tbl_locations values (	@city)     end");
            
            Execute.Sql(@"CREATE proc sp_sources_add @code nvarchar(15),@name nvarchar(25)     as
                        begin
             insert into tbl_sources values (@code,	@name) end");
           
            Execute.Sql(@"	CREATE proc sp_process_statuses_add @code nvarchar(15),@status nvarchar(50),@colour nvarchar(10)='#FFFFFF'

                       as
                       begin
                       insert into tbl_process_statuses values (@code,	@status,@colour)end");
          
            Execute.Sql(@"CREATE proc sp_vacancies_add @code nvarchar(15),@name nvarchar(50),@vacancy bigint =0

                         as
                         begin
                         insert into tbl_vacancies values (	@code,	@name,	@vacancy)
                                      end");
            Execute.Sql(@"CREATE proc sp_process_stages_add @code nvarchar(15),@status nvarchar(50)

                         as
                                 begin
                              insert into tbl_process_stages values (@code,	@status)     end");
            Execute.Sql(@"CREATE proc sp_interview_round_statuses_add @status nvarchar(20)
                         as
                         begin
                      insert into tbl_interview_round_statuses values (	@status)     end");
        }
        public override void Down()
        {

        }
    }


    public class Init
    {
        public static Logger log = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Configure the dependency injection services
        /// </summary>

        public static IServiceProvider CreateServices()
        {
            //var a = new ServiceCollection();
            //var b= a.AddFluentMigratorCore();

            return new ServiceCollection()
                // Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb =>
                {
                    IMigrationRunnerBuilder supp = null;

                    supp = rb
                     // .AsGlobalPreview()
                     // Add SQLite support to FluentMigrator
                     .AddSqlServer();

                    //supp = rb.AddSQLite();

                    // Set the connection string
                    supp.WithGlobalConnectionString("Data Source=DESKTOP-T3N0J77;Initial Catalog=RecruitMain;Integrated Security=True")
                   // Define the assembly containing the migrations
                   .ScanIn(typeof(CreateTables).Assembly).For.Migrations();
                }
                )
                // Enable logging to console in the FluentMigrator way
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                // Build the service provider
                .BuildServiceProvider(false);
        }

        /// <summary>
        /// Update the database
        /// </summary>
        public static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            log.Info("[UpdateDatabase]:Migrate Start");
            runner.MigrateUp();
            log.Info("[UpdateDatabase]:Migrate End");
        }
    }
}
