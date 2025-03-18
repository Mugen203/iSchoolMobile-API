using iSchool_Solution.Entities;
using Microsoft.EntityFrameworkCore;

namespace iSchool_Solution.Data.SeedData;

public static class SeedCourses
{
    // ---------- FACULTY OF SCIENCE - Computer Science Department Courses ----------
    public static Guid Cs101CourseId = Guid.Parse("8fd7171a-8a59-4208-aabb-1c0699259052");
    public static Guid Cosc115CourseId = Guid.Parse("52d2190e-c7a3-4f7b-ab3b-731e82216d02");
    public static Guid Cosc113CourseId = Guid.Parse("28a3020d-c97f-4f0b-a559-b59cfe2a6d3c");
    public static Guid Cosc130CourseId = Guid.Parse("babc17e9-4b27-4ee1-8c79-5c39179eeb68");
    public static Guid Cosc116CourseId = Guid.Parse("8041883e-8a68-42e0-8213-3f8c2669c73e");
    public static Guid Cosc124CourseId = Guid.Parse("f29033fa-ffd0-4c70-8726-a4eefa5f72ef");
    public static Guid Cosc210CourseId = Guid.Parse("7ff93b84-31e2-4e02-81d1-68785909ccb9");
    public static Guid Cosc230CourseId = Guid.Parse("1f1f83d3-6271-4ac5-964f-2805ae049fa1");
    public static Guid Cosc271CourseId = Guid.Parse("4459b5db-fac2-4188-96ac-cf2d4e562f14");
    public static Guid Cosc280CourseId = Guid.Parse("7e542e0d-713f-437f-8a1d-0133a004b722");
    public static Guid Cosc214CourseId = Guid.Parse("eeb2ed1f-1b0f-4a3c-bad3-aab3a35a4796");
    public static Guid Cosc224CourseId = Guid.Parse("012bdf77-0b02-4d88-8da0-105ba9f1f829");
    public static Guid Cosc272CourseId = Guid.Parse("1b006764-b19a-402b-a17a-f9a12d5f4b76");
    public static Guid Cosc260CourseId = Guid.Parse("b8391957-9ad4-4134-8b65-86d891b57d07");
    public static Guid Cosc331CourseId = Guid.Parse("e023c552-f2a5-48a5-88d6-f13f55b6d5bb");
    public static Guid Cosc360CourseId = Guid.Parse("fb4cf15a-f794-4b59-bc78-3be63b7b8310");
    public static Guid Cosc255CourseId = Guid.Parse("25a7e084-5ce1-48e8-bca7-9cada78ffa26");
    public static Guid Cosc257CourseId = Guid.Parse("ab899bae-a14b-4a18-8ff5-b70be8405acc");
    public static Guid Cosc361CourseId = Guid.Parse("a793836a-dd04-40e6-a610-04c45c411837");
    public static Guid Cosc425CourseId = Guid.Parse("f489fc5f-0029-4a95-9fa9-ec6d63a33e0c");
    public static Guid Cosc357CourseId = Guid.Parse("8f5abb46-f621-4b96-9e1b-e6e84aba4b41");
    public static Guid Cosc240CourseId = Guid.Parse("c0fff6d8-640b-44a4-ba64-9c550052ef80");
    public static Guid Cosc364CourseId = Guid.Parse("064f2d40-55de-4ff5-a56c-c57c1dd562f4");
    public static Guid Cosc370CourseId = Guid.Parse("96d16898-bce0-4f23-9ab1-9507e904b293");
    public static Guid Cosc325CourseId = Guid.Parse("20acdf30-8b86-4b77-921d-02b0bc9ee0d5");
    public static Guid Cosc250CourseId = Guid.Parse("435500b2-b00d-4a63-8571-a77f5aadc28d");
    public static Guid Cosc429CourseId = Guid.Parse("e1f195d3-4c19-4b33-a3ae-f2ac1f4e243e");
    public static Guid Cosc445CourseId = Guid.Parse("2722aef8-8ead-4d5f-8841-e905e4f8dc63");
    public static Guid Cosc447CourseId = Guid.Parse("86293383-c8de-4941-b83a-4b7c88a53ae1");
    public static Guid Cosc455CourseId = Guid.Parse("3d27b128-0ce6-4990-9c5a-a21de5a414b5");
    public static Guid Cosc330CourseId = Guid.Parse("e806b9b1-e27f-48df-9534-abe0ec02a5ab");
    public static Guid Cosc491CourseId = Guid.Parse("3d5c9296-405d-4648-addf-2b0706b77169");
    public static Guid Cosc436CourseId = Guid.Parse("58bbeec1-d95e-41f9-af74-a517457235c6");
    public static Guid Cosc440CourseId = Guid.Parse("baa9502b-bf06-451c-a53b-357973a88fd1");
    public static Guid Cosc466CourseId = Guid.Parse("156ae504-b1fb-4981-af79-8a70f8b19bfa");
    public static Guid Cosc480CourseId = Guid.Parse("4e99258c-12cd-46b4-bf5b-136de3664bdb");
    public static Guid Cosc492CourseId = Guid.Parse("e528b274-541c-4ba6-b4a8-5480a190f7be");
    public static Guid Stat282CourseId = Guid.Parse("1b84cd21-2550-41d3-b3d4-7a985e71d1ea");
    public static Guid Cscd210CourseId = Guid.Parse("520f8d39-11bd-4e16-9add-79661a45985e");

    // ---------- FACULTY OF ARTS & SOCIAL SCIENCES - Theology Department Courses ----------
    public static Guid Relb163CourseId = Guid.Parse("87097a1a-aca0-42f0-8ce3-65995891a0ea");
    public static Guid Relb250CourseId = Guid.Parse("fc6943fa-c904-4b85-9232-eba8c33c485e");
    public static Guid Relt385CourseId = Guid.Parse("fae9d171-eecf-4b51-87c6-08e9b8bb3b21");
    public static Guid Relg451CourseId = Guid.Parse("fd9a3b1a-af4d-4232-8663-bb0af5c428a0");

    // ---------- SCHOOL OF BUSINESS - Business Department Courses ----------
    public static Guid Acct210CourseId = Guid.Parse("0922f512-59fd-43c4-9d36-cdd18fccfb13");
    public static Guid Mgnt255CourseId = Guid.Parse("095a4f84-f388-4a49-9994-43eb52ec18e0");

    // ---------- GENERAL EDUCATION Courses (University Wide) ----------
    public static Guid Engl111CourseId = Guid.Parse("0badf6bd-77ef-4c6d-a568-912b57daf884");
    public static Guid Engl112CourseId = Guid.Parse("13a87b42-12ce-4cbc-8011-fc2c792f29e5");
    public static Guid Cmme115CourseId = Guid.Parse("13c34157-f376-4a31-9391-7fdd4d7fbdb7");
    public static Guid Fren121CourseId = Guid.Parse("1897059a-c3fc-4cb3-a6dc-0aa23f62fc4d");
    public static Guid Peac100CourseId = Guid.Parse("1a46ac1d-c607-4225-9002-e14a4c1e3363");
    public static Guid Gned125CourseId = Guid.Parse("20a3f858-958e-42b0-b841-e907b592ce0e");
    public static Guid Phys103CourseId = Guid.Parse("2274f76c-d939-47c9-89c2-8284728f2c7a");
    public static Guid Psyc105CourseId = Guid.Parse("23665740-f571-4a6e-b3b4-8cdcb719d2fc");
    public static Guid Gned230CourseId = Guid.Parse("30677d50-b76e-4826-b24a-b7251602ee22");
    public static Guid Hlth200CourseId = Guid.Parse("32ff3746-075f-4a74-bdaa-ed776cf854ff");
    public static Guid Afst205CourseId = Guid.Parse("564d341f-7ccf-4eb4-b250-f32d6cb1c633");
    public static Guid Afst243CourseId = Guid.Parse("59c320f0-4ab1-4f43-bd8a-c4cfa2b687d7");
    public static Guid Math171CourseId = Guid.Parse("60efbe37-61c0-4dc0-93ef-5d20358e8a30");
    public static Guid Math172CourseId = Guid.Parse("62330761-ad34-4969-96c7-47eb3c70f552");


    public static void Seed(ModelBuilder builder,
        Guid departmentOfComputerScienceId,
        Guid departmentOfTheologicalStudiesId,
        Guid departmentOfBusinessId,
        Guid departmentOfGeneralEducationId)
    {
        builder.Entity<Course>().HasData(
            // ---------- FACULTY OF SCIENCE - Computer Science Department Courses ----------
            new Course
            {
                CourseID = Cs101CourseId,
                CourseCode = "CS101",
                CourseName = "Introduction to Computer Science",
                CourseDescription =
                    "Provides a foundational overview of the field of computer science.\nCovers basic concepts and principles.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc115CourseId,
                CourseCode = "COSC115",
                CourseName = "Introduction to Computer Science 1",
                CourseDescription =
                    "First part of introductory computer science course.\nExplores basic concepts and problem-solving.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc113CourseId,
                CourseCode = "COSC113",
                CourseName = "Elements of Programming",
                CourseDescription =
                    "Introduces fundamental programming concepts and techniques.\nFocuses on problem-solving and algorithm design.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc130CourseId,
                CourseCode = "COSC130",
                CourseName = "Digital Electronics",
                CourseDescription =
                    "Introduces principles of digital electronics and logic circuits.\nCovers digital components and systems.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc116CourseId,
                CourseCode = "COSC116",
                CourseName = "Introduction to Computer Science II",
                CourseDescription =
                    "Second part of introductory computer science course.\nBuilds on concepts from Introduction to Computer Science I.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc124CourseId,
                CourseCode = "COSC124",
                CourseName = "Procedural Programming",
                CourseDescription =
                    "Focuses on procedural programming paradigms and techniques.\nEmphasizes structured programming and modular design.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc210CourseId,
                CourseCode = "COSC210",
                CourseName = "Numerical Methods",
                CourseDescription =
                    "Covers numerical methods for solving mathematical problems.\nFocuses on algorithms and computational techniques.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Math171CourseId,
                DepartmentID = departmentOfGeneralEducationId,
                CourseCode = "MATH171",
                CourseName = "INTRODUCTORY MATHS FOR COMPUTER SCIENCE",
                CourseCredits = 3,
                CourseDescription =
                    "Introduces mathematical concepts fundamental to computer science. Covers algebraic structures, logic, and basic calculus."
            },
            new Course
            {
                CourseID = Math172CourseId,
                DepartmentID = departmentOfGeneralEducationId,
                CourseCode = "MATH172",
                CourseName = "DISCRETE AND CONTINUOUS MATHEMATICS",
                CourseCredits = 3,
                CourseDescription =
                    "Explores both discrete mathematical structures and continuous mathematical concepts relevant to computing."
            },
            new Course
            {
                CourseID = Cscd210CourseId,
                DepartmentID = departmentOfComputerScienceId,
                CourseCode = "CSCD210",
                CourseName = "NUMERICAL METHODS",
                CourseCredits = 3,
                CourseDescription =
                    "Studies computational approaches to solving mathematical problems. Focuses on numerical algorithms and their implementation."
            },
            new Course
            {
                CourseID = Cosc230CourseId,
                CourseCode = "COSC230",
                CourseName = "Database Systems Design",
                CourseDescription =
                    "Introduces database concepts and design principles.\nCovers relational database models and SQL.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc271CourseId,
                CourseCode = "COSC271",
                CourseName = "Data Communication & Computer Network I",
                CourseDescription =
                    "First part of data communication and networking course.\nCovers network fundamentals and protocols.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc280CourseId,
                CourseCode = "COSC280",
                CourseName = "Information Systems",
                CourseDescription =
                    "Introduces concepts of information systems and their role in organizations.\nCovers system development and management.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc214CourseId,
                CourseCode = "COSC214",
                CourseName = "Computer Organization",
                CourseDescription =
                    "Covers the organization and architecture of computer systems.\nExplores hardware components and their interactions.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc224CourseId,
                CourseCode = "COSC224",
                CourseName = "Object-Oriented Programming",
                CourseDescription =
                    "Focuses on object-oriented programming principles and paradigms.\nEmphasizes design patterns and software development.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc272CourseId,
                CourseCode = "COSC272",
                CourseName = "Data Communication & Computer Network II",
                CourseDescription =
                    "Second part of data communication and networking course.\nBuilds upon concepts from Network I.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc260CourseId,
                CourseCode = "COSC260",
                CourseName = "Systems Analysis and Design",
                CourseDescription =
                    "Covers methodologies for analyzing, designing, and developing systems.\nEmphasizes software engineering principles.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc331CourseId,
                CourseCode = "COSC331",
                CourseName = "Computer Graphics",
                CourseDescription =
                    "Introduces principles and techniques of computer graphics.\nCovers 2D and 3D graphics rendering and animation.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc360CourseId,
                CourseCode = "COSC360",
                CourseName = "Web Application Development",
                CourseDescription =
                    "Focuses on developing web-based applications and services.\nCovers front-end and back-end technologies.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc255CourseId,
                CourseCode = "COSC255",
                CourseName = "Operating Systems",
                CourseDescription =
                    "Explores the principles and design of operating systems.\nCovers process management, memory management, and file systems.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc257CourseId,
                CourseCode = "COSC257",
                CourseName = "Computer Architecture & Microprocessor Systems", // Combined name from image
                CourseDescription =
                    "Covers computer architecture and microprocessor systems.\nExplores hardware design and organization.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc361CourseId,
                CourseCode = "COSC361",
                CourseName = "Data Structures & Algorithm I",
                CourseDescription =
                    "First part of data structures and algorithms course.\nCovers fundamental data structures and algorithm analysis.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc425CourseId,
                CourseCode = "COSC425",
                CourseName = "Mobile Application Development",
                CourseDescription =
                    "Focuses on developing applications for mobile platforms.\nCovers mobile OS, UI design, and development tools.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc357CourseId,
                CourseCode = "COSC357",
                CourseName = "Project Planning and Management",
                CourseDescription =
                    "Covers principles and techniques of project planning and management.\nFocuses on software project management.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc240CourseId,
                CourseCode = "COSC240",
                CourseName = "Systems Programming",
                CourseDescription =
                    "Focuses on low-level programming and system-level interactions.\nCovers OS APIs and system calls.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc364CourseId,
                CourseCode = "COSC364",
                CourseName = "Research Methods",
                CourseDescription =
                    "Introduces research methodologies and techniques.\nPrepares students for conducting research projects.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc370CourseId,
                CourseCode = "COSC370",
                CourseName = "Operations Research",
                CourseDescription =
                    "Covers operations research techniques for optimization and decision-making.\nApplies mathematical modeling to solve real-world problems.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc325CourseId,
                CourseCode = "COSC325",
                CourseName = "Computer Security",
                CourseDescription =
                    "Introduces principles and practices of computer security.\nCovers threats, vulnerabilities, and security mechanisms.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc250CourseId,
                CourseCode = "COSC250",
                CourseName = "Computer Ethics",
                CourseDescription =
                    "Explores ethical issues in computing and information technology.\nDiscusses social and professional responsibilities.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc429CourseId,
                CourseCode = "COSC429",
                CourseName = "Cloud Computing Systems",
                CourseDescription =
                    "Covers principles and technologies of cloud computing.\nExplores cloud platforms and service models.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc445CourseId,
                CourseCode = "COSC445",
                CourseName = "Entrepreneurship and Human Development", // Combined name from image
                CourseDescription =
                    "Covers entrepreneurship principles and human development in technology.\nFocuses on innovation and business skills.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc447CourseId,
                CourseCode = "COSC447",
                CourseName = "Software Engineering",
                CourseDescription =
                    "Covers advanced software engineering methodologies and practices.\nEmphasizes team-based software development.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc455CourseId,
                CourseCode = "COSC455",
                CourseName = "Introduction to Artificial Intelligence",
                CourseDescription =
                    "Introduces fundamental concepts and techniques of artificial intelligence.\nCovers AI algorithms and applications.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc330CourseId,
                CourseCode = "COSC330",
                CourseName = "Computer Simulation & Systems Modeling", // Combined name from image
                CourseDescription =
                    "Covers techniques for computer simulation and systems modeling.\nApplies computational methods to model real-world systems.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc491CourseId,
                CourseCode = "COSC491",
                CourseName = "Final Year Project 1",
                CourseDescription =
                    "First part of the final year project in computer science.\nStudents begin research and project development.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc436CourseId,
                CourseCode = "COSC436",
                CourseName = "Computer & Cyber Forensics (Elective 1)", // Combined name from image, Elective 1
                CourseDescription =
                    "Elective course focusing on computer and cyber forensics.\nCovers digital investigation techniques and cybercrime analysis.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc440CourseId,
                CourseCode = "COSC440",
                CourseName = "Computer Vision (Elective 2)", // Combined name from image, Elective 2
                CourseDescription =
                    "Elective course on computer vision principles and applications.\nCovers image processing and analysis techniques.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc466CourseId,
                CourseCode = "COSC466",
                CourseName = "Systems and Network Administration (Elective 3)", // Combined name from image, Elective 3
                CourseDescription =
                    "Elective course on systems and network administration.\nCovers server management, networking, and security.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc480CourseId,
                CourseCode = "COSC480",
                CourseName = "Compiler Design",
                CourseDescription =
                    "Covers the principles and techniques of compiler design.\nExplores lexical analysis, parsing, and code generation.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },
            new Course
            {
                CourseID = Cosc492CourseId,
                CourseCode = "COSC492",
                CourseName = "Final Year Project II",
                CourseDescription =
                    "Second part of the final year project in computer science.\nStudents complete their research and project development.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            },

            // ---------- FACULTY OF ARTS & SOCIAL SCIENCES - Theology Department Courses ----------
            new Course
            {
                CourseID = Relb163CourseId,
                CourseCode = "RELB163",
                CourseName = "Life and Teachings of Jesus",
                CourseDescription =
                    "Explores the life, ministry, and teachings of Jesus Christ.\nProvides a theological perspective.",
                CourseCredits = 3,
                DepartmentID = departmentOfTheologicalStudiesId
            },
            new Course
            {
                CourseID = Relb250CourseId,
                CourseCode = "RELB251",
                CourseName = "Principles of Christian Faith",
                CourseDescription =
                    "Explores fundamental principles of Christian faith and theology.\nProvides a comprehensive overview.",
                CourseCredits = 3,
                DepartmentID = departmentOfTheologicalStudiesId
            },
            new Course
            {
                CourseID = Relt385CourseId,
                CourseCode = "RELT385",
                CourseName = "Introduction to Biblical Foundation & Ethics",
                CourseDescription =
                    "Introduces biblical foundations and ethical principles.\nExplores theological and ethical frameworks.",
                CourseCredits = 3,
                DepartmentID = departmentOfTheologicalStudiesId
            },
            new Course
            {
                CourseID = Relg451CourseId,
                CourseCode = "RELG451",
                CourseName = "Bible and Family Dynamics",
                CourseDescription =
                    "Explores biblical perspectives on family dynamics and relationships.\nProvides theological insights into family life.",
                CourseCredits = 3,
                DepartmentID = departmentOfTheologicalStudiesId
            },

            // ---------- SCHOOL OF BUSINESS - Business Department Courses ----------
            new Course
            {
                CourseID = Acct210CourseId,
                CourseCode = "ACCT210",
                CourseName = "Introduction to Accounting",
                CourseDescription =
                    "Introduces basic accounting principles and practices.\nCovers financial accounting fundamentals.",
                CourseCredits = 3,
                DepartmentID = departmentOfBusinessId
            },
            new Course
            {
                CourseID = Mgnt255CourseId,
                CourseCode = "MGNT234",
                CourseName = "Principles of Management",
                CourseDescription =
                    "Introduces fundamental management principles and theories.\nCovers planning, organizing, leading, and controlling.",
                CourseCredits = 3,
                DepartmentID = departmentOfBusinessId
            },

            // ---------- GENERAL EDUCATION Courses (University Wide) ----------
            new Course
            {
                CourseID = Engl111CourseId,
                CourseCode = "ENGL111",
                CourseName = "Language and Writing Skills I",
                CourseDescription =
                    "Develops fundamental language and writing skills.\nFocuses on grammar, vocabulary, and basic composition.",
                CourseCredits = 2,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Engl112CourseId,
                CourseCode = "ENGL112",
                CourseName = "Language and Writing Skills II",
                CourseDescription =
                    "Continues development of language and writing skills.\nBuilds upon skills from Language and Writing Skills I.",
                CourseCredits = 2,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Cmme115CourseId,
                CourseCode = "CMME115",
                CourseName = "Introduction to Communication Skills",
                CourseDescription =
                    "Introduces fundamental communication theories and practices.\nDevelops effective communication abilities.",
                CourseCredits = 2,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Fren121CourseId,
                CourseCode = "FREN121",
                CourseName = "French for General Communication 1",
                CourseDescription =
                    "Introduces basic French language skills for communication.\nCovers fundamental grammar and vocabulary.",
                CourseCredits = 2,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Peac100CourseId,
                CourseCode = "PEAC100",
                CourseName = "Physical Activity",
                CourseDescription =
                    "Promotes physical fitness and well-being through activity.\nEncourages a healthy lifestyle.",
                CourseCredits = 0, // NC - Non-Credit
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Gned125CourseId,
                CourseCode = "GNED125",
                CourseName = "Study Skills",
                CourseDescription =
                    "Develops effective learning and study strategies.\nEnhances academic performance and efficiency.",
                CourseCredits = 1,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Phys103CourseId,
                CourseCode = "PHYS103",
                CourseName = "Physics",
                CourseDescription =
                    "Introduces fundamental principles of physics.\nCovers mechanics, heat, light, and sound.",
                CourseCredits = 3,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Psyc105CourseId,
                CourseCode = "SOC1105/PSYC105", // Combined Course Code
                CourseName = "General Sociology OR Intro to Psychology", // Combined Course Name
                CourseDescription =
                    "Introduces basic concepts of Sociology OR Psychology.\nStudents choose one of these introductory social science courses.",
                CourseCredits = 3,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Gned230CourseId,
                CourseCode = "GNED230",
                CourseName = "Career Exploration and Planning",
                CourseDescription =
                    "Guides students in exploring career options and planning their future.\nDevelops career readiness skills.",
                CourseCredits = 1,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Hlth200CourseId,
                CourseCode = "HLTH200",
                CourseName = "Health Principles",
                CourseDescription =
                    "Explores key health principles and practices.\nPromotes healthy living and disease prevention.",
                CourseCredits = 3,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Afst205CourseId,
                CourseCode = "AFST205",
                CourseName = "African Studies - Chieftancy and Development",
                CourseDescription =
                    "African Studies Course - Placeholder. Replace with actual course details for Group A.",
                CourseCredits = 1,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Afst243CourseId,
                CourseCode = "AFST243",
                CourseName = "African Studies - Group B",
                CourseDescription =
                    "African Studies Course - Placeholder. Replace with actual course details for Group B.",
                CourseCredits = 1,
                DepartmentID = departmentOfGeneralEducationId
            },
            new Course
            {
                CourseID = Stat282CourseId,
                CourseCode = "STAT282",
                CourseName = "Introduction to Statistics",
                CourseDescription = "This course introduces fundamental concepts in statistics.",
                CourseCredits = 3,
                DepartmentID = departmentOfComputerScienceId
            }

            // ... (REST OF THE COURSES FROM IMAGE) ...
        );
    }
}