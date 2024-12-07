using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfrastructureLayer.Context.Configuratoins
{
    public class MedicalConditionCnofiguration : IEntityTypeConfiguration<MedicalCondition>
    {
        public void Configure(EntityTypeBuilder<MedicalCondition> builder)
        {
            builder.ToTable("MedicalConditions");


            builder.HasKey(mc => mc.Id);


            builder.Property(mc => mc.Id).ValueGeneratedOnAdd();


            builder.Property(mc => mc.ConditionName).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired();


            builder.HasData(LoadMedicalCondition());


        }
        private static List<MedicalCondition> LoadMedicalCondition()
        {
            return new List<MedicalCondition>
        {
                    new MedicalCondition { Id = 1,  ConditionName ="Hypertension (High Blood Pressure)"                      },
                    new MedicalCondition { Id = 2,  ConditionName ="Hypotension (Low Blood Pressure)"                        },
                    new MedicalCondition { Id = 3,  ConditionName ="Anemia"                                                  },
                    new MedicalCondition { Id = 4,  ConditionName ="Postural Orthostatic Tachycardia Syndrome (POTS)"        },
                    new MedicalCondition { Id = 5,  ConditionName ="Arrhythmias (Irregular Heartbeats)"                      },
                    new MedicalCondition { Id = 6,  ConditionName ="Congenital Heart Defects"                                },
                    new MedicalCondition { Id = 7,  ConditionName ="Diabetes Mellitus (Type 1 and Type 2)"                   },
                    new MedicalCondition { Id = 8,  ConditionName ="Obesity"                                                 },
                    new MedicalCondition { Id = 9,  ConditionName ="Metabolic Syndrome"                                      },
                    new MedicalCondition { Id = 10, ConditionName ="Asthma"                                                  },
                    new MedicalCondition { Id = 11, ConditionName ="Chronic Bronchitis"                                      },
                    new MedicalCondition { Id = 12, ConditionName ="Allergies (Seasonal and Food Allergies)"                 },
                    new MedicalCondition { Id = 13, ConditionName ="Cystic Fibrosis"                                         },
                    new MedicalCondition { Id = 14, ConditionName ="Epilepsy"                                                },
                    new MedicalCondition { Id = 15, ConditionName ="Migraine"                                                },
                    new MedicalCondition { Id = 16, ConditionName ="Concussion"                                              },
                    new MedicalCondition { Id = 17, ConditionName ="Attention Deficit Hyperactivity Disorder (ADHD)"         },
                    new MedicalCondition { Id = 18, ConditionName ="Tourette Syndrome"                                       },
                    new MedicalCondition { Id = 19, ConditionName ="Anxiety Disorders (Generalized Anxiety, Social Anxiety)" },
                    new MedicalCondition { Id = 20, ConditionName ="Depression"                                              },
                    new MedicalCondition { Id = 21, ConditionName ="Bipolar Disorder"                                        },
                    new MedicalCondition { Id = 22, ConditionName ="Obsessive-Compulsive Disorder (OCD)"                     },
                    new MedicalCondition { Id = 23, ConditionName ="Post-Traumatic Stress Disorder (PTSD)"                   },
                    new MedicalCondition { Id = 24, ConditionName ="Eating Disorders (Anorexia Nervosa, Bulimia Nervosa)"    },
                    new MedicalCondition { Id = 25, ConditionName ="Scoliosis"                                               },
                    new MedicalCondition { Id = 26, ConditionName ="Chronic Pain Syndromes (e.g., Fibromyalgia)"             },
                    new MedicalCondition { Id = 27, ConditionName ="Osteochondritis Dissecans"                               },
                    new MedicalCondition { Id = 28, ConditionName ="Irritable Bowel Syndrome (IBS)"                          },
                    new MedicalCondition { Id = 29, ConditionName ="Celiac Disease"                                          },
                    new MedicalCondition { Id = 30, ConditionName ="Gastroesophageal Reflux Disease (GERD)"                  },
                    new MedicalCondition { Id = 31, ConditionName ="Constipation Disorders"                                  },
                    new MedicalCondition { Id = 32, ConditionName ="Acne"                                                    },
                    new MedicalCondition { Id = 33, ConditionName ="Eczema (Atopic Dermatitis)"                              },
                    new MedicalCondition { Id = 34, ConditionName ="Psoriasis"                                               },
                    new MedicalCondition { Id = 35, ConditionName ="Contact Dermatitis"                                      },
                    new MedicalCondition { Id = 36, ConditionName ="Mononucleosis"                                           },
                    new MedicalCondition { Id = 37, ConditionName ="Flu and Other Viral Infections"                          },
                    new MedicalCondition { Id = 38, ConditionName ="Hepatitis"                                               },
                    new MedicalCondition { Id = 39, ConditionName ="Tuberculosis (TB)"                                       },
                    new MedicalCondition { Id = 40, ConditionName ="Thyroid Disorders (Hypothyroidism, Hyperthyroidism)"     },
                    new MedicalCondition { Id = 41, ConditionName ="Polycystic Ovary Syndrome (PCOS)"                        },
                    new MedicalCondition { Id = 42, ConditionName ="Growth Hormone Deficiency"                               },
                    new MedicalCondition { Id = 43, ConditionName ="Lupus"                                                   },
                    new MedicalCondition { Id = 44, ConditionName ="Type 1 Diabetes (autoimmune)"                            },
                    new MedicalCondition { Id = 45, ConditionName ="Sickle Cell Disease"                                     },
                    new MedicalCondition { Id = 46, ConditionName ="Hemophilia"                                              },
                    new MedicalCondition { Id = 47, ConditionName ="Thalassemia"                                             },
                    new MedicalCondition { Id = 48, ConditionName ="Chronic Fatigue Syndrome (CFS)"                          },
                    new MedicalCondition { Id = 49, ConditionName ="Vision Problems (Myopia, Hyperopia, Astigmatism)"        },
                    new MedicalCondition { Id = 50, ConditionName ="Hearing Impairment"                                      },
                    new MedicalCondition { Id = 51, ConditionName ="Skin Infections (like MRSA)"                             },
                    new MedicalCondition { Id = 52, ConditionName ="Insomnia"                                                },
                    new MedicalCondition { Id = 53, ConditionName ="Sleep Apnea"                                             },
                    new MedicalCondition { Id = 54, ConditionName ="Restless Legs Syndrome"                                  }
        };
        }
    }

}
